using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BnGClub.Controllers
{
    public class SchedulesController : Controller
    {

        private readonly BnGClubContext _context;

        public SchedulesController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var bnGClubContext = _context.Schedules.Include(s => s.Activities);
            return View(await bnGClubContext.ToListAsync());
        }

        public void DownloadSchedules()
        {
            //Get the Sechdules
            var sech = from a in _context.Schedules
                        .Include(a => a.startTime)
                        .Include(a => a.endTime)
                        .Include(a => a.dateAct)
                       orderby a.dateAct descending
                       select new
                       {
                           Date = a.dateAct,
                           Start = a.startTime,
                           End = a.endTime,
                           Activity = a.Activities.actName,
                           Place = a.Activities.actAvailablePlace
                       };
            //How many rows?
            int numRows = sech.Count();

            if (numRows > 0) //We have data
            {
                //Create a new spreadsheet from scratch.
                ExcelPackage excel = new ExcelPackage();

                var workSheet = excel.Workbook.Worksheets.Add("Sechdules");

                //Note: Cells[row, column]
                workSheet.Cells[3, 1].LoadFromCollection(sech, true);

                //Style first column for dates
                workSheet.Column(1).Style.Numberformat.Format = "yyyy-mm-dd";

                //Style fee column for time
                workSheet.Column(2).Style.Numberformat.Format = "yyyy-mm-dd h:mm";
                workSheet.Column(3).Style.Numberformat.Format = "yyyy-mm-dd h:mm";

                //Set Style and backgound colour of headings
                using (ExcelRange headings = workSheet.Cells[3, 1, 3, 7])
                {
                    headings.Style.Font.Bold = true;
                    var fill = headings.Style.Fill;
                    fill.PatternType = ExcelFillStyle.Solid;
                    fill.BackgroundColor.SetColor(Color.LightBlue);
                }

                //Autofit columns
                workSheet.Cells.AutoFitColumns();

                //Add a title and timestamp at the top of the report
                workSheet.Cells[1, 1].Value = "Schedules Report";
                using (ExcelRange Rng = workSheet.Cells[1, 1, 1, 6])
                {
                    Rng.Merge = true; //Merge columns start and end range
                    Rng.Style.Font.Bold = true; //Font should be bold
                    Rng.Style.Font.Size = 18;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                //Since the time zone where the server is running can be different, adjust to 
                //Local for us.
                DateTime utcDate = DateTime.UtcNow;
                TimeZoneInfo esTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime localDate = TimeZoneInfo.ConvertTimeFromUtc(utcDate, esTimeZone);
                using (ExcelRange Rng = workSheet.Cells[2, 6])
                {
                    Rng.Value = "Created: " + localDate.ToShortTimeString() + " on " +
                        localDate.ToShortDateString();
                    Rng.Style.Font.Bold = true; //Font should be bold
                    Rng.Style.Font.Size = 12;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.Headers["content-disposition"] = "attachment;  filename=Sechdules.xlsx";
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.Body);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertFromExcel(IFormFile theExcel)
        {
            ExcelPackage excel;
            using (var memoryStream = new MemoryStream())
            {
                await theExcel.CopyToAsync(memoryStream);
                excel = new ExcelPackage(memoryStream);
            }
            var workSheet = excel.Workbook.Worksheets[0];
            var start = workSheet.Dimension.Start;
            var end = workSheet.Dimension.End;
            if (workSheet.Cells[1,1].Text == "Schedules Report")
            {
                for (int row = start.Row + 3; row <= end.Row; row++)
                {
                    // Row by row...
                    Schedules a = new Schedules
                    {
                        dateAct = DateTime.Parse(workSheet.Cells[row, 1].Text),
                        startTime = DateTime.Parse(workSheet.Cells[row, 2].Text),
                        endTime = DateTime.Parse(workSheet.Cells[row, 3].Text),
                        ActID = _context.Activities.FirstOrDefault(ac => ac.actName == workSheet.Cells[row, 4].Text).ID
                    };
                    _context.Schedules.Add(a);
                };
            }
            else
            {
                for (int row = start.Row; row <= end.Row; row++)
                {
                    // Row by row...
                    Schedules a = new Schedules
                    {
                        dateAct = DateTime.Parse(workSheet.Cells[row, 1].Text),
                        startTime = DateTime.Parse(workSheet.Cells[row, 2].Text),
                        endTime = DateTime.Parse(workSheet.Cells[row, 3].Text),
                        ActID = _context.Activities.FirstOrDefault(ac => ac.actName == workSheet.Cells[row, 4].Text).ID
                    };
                    if (a.startTime > DateTime.Now)
                    {
                        _context.Schedules.Add(a);
                    }
                };
            }
            
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id, string activeTab)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Clear the active tab
            ViewData["basic"] = "";
            ViewData["announcemets"] = "";

            //Set it
            if (String.IsNullOrEmpty(activeTab))
            {
                ViewData["basic"] = "active";
            }
            else
            {
                ViewData[activeTab] = "active";
            }


            var schedules = await _context.Schedules
                .Include(d => d.startTime)
                .Include(d => d.endTime)
                .Include(d => d.dateAct)
                .Include(d => d.ActID)
                .FirstOrDefaultAsync(m => m.ID == id);


            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }



        // GET: Schedules/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,startTime,endTime,dateAct,ActID")] Schedules schedules)
        {
            if (ModelState.IsValid)
            {
                if (schedules.dateAct >= DateTime.Today && schedules.startTime >= DateTime.Now)
                {
                    _context.Add(schedules);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateDropDownLists(schedules);
            return View(schedules);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules.FindAsync(id);
            if (schedules == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(schedules);
            return View(schedules);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,startTime,endTime,dateAct,ActID")] Schedules schedules)
        {
            if (id != schedules.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulesExists(schedules.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(schedules);
            return View(schedules);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.Activities)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedules = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedules);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList ActivitySelectList(int? id)
        {
            var dQuery = from d in _context.Activities
                         orderby d.actName
                         select d;
            return new SelectList(dQuery, "ID", "actName", id);
        }

        private void PopulateDropDownLists(Schedules schedules = null)
        {
            ViewData["ActID"] = ActivitySelectList(schedules?.ActID);
        }

        private bool SchedulesExists(int id)
        {
            return _context.Schedules.Any(e => e.ID == id);
        }
    }
}
