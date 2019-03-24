using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace BnGClub.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly BnGClubContext _context;

        public ActivitiesController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: Activitys
        public async Task<IActionResult> Index()
        {
            var bnGClubContext = _context.Activities.Include(a => a.ActType).Include(a => a.Leader);
            return View(await bnGClubContext.ToListAsync());
        }

        // GET: Activitys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitys = await _context.Activities
                .Include(a => a.ActType)
                .Include(a => a.Leader)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (activitys == null)
            {
                return NotFound();
            }

            return View(activitys);
        }

        // GET: Activitys/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: Activitys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,actName,actDescription,actCode,actRequirement,actAvailablePlace,LeaderID,ActTypeID")] Activities activities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(activities);
            return View(activities);
        }

        // GET: Activitys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities.FindAsync(id);
            if (activities == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(activities);
            return View(activities);
        }

        // POST: Activitys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,actName,actDescription,actCode,actRequirement,actAvailablePlace,LeaderID,ActTypeID")] Activities activities)
        {
            if (id != activities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitysExists(activities.ID))
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
            PopulateDropDownLists(activities);
            return View(activities);
        }

        // GET: Activitys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .Include(a => a.ActType)
                .Include(a => a.Leader)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        // POST: Activitys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activities = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(activities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList ActTypeSelectList(int? id)
        {
            var dQuery = from d in _context.ActTypes
                         orderby d.acttypeName
                         select d;
            return new SelectList(dQuery, "ID", "acttypeName", id);
        }

        private SelectList LeaderSelectList(int? id)
        {
            var dQuery = from d in _context.Leaders
                         orderby d.leaderFName
                         select d;
            return new SelectList(dQuery, "ID", "FullName", id);
        }

        private void PopulateDropDownLists(Activities activities = null)
        {
            ViewData["ActTypeID"] = ActTypeSelectList(activities?.ActTypeID);
            ViewData["LeaderID"] = LeaderSelectList(activities?.LeaderID);
        }

        public void DownloadActivities()
        {
            //Get the activities
            var acts = from a in _context.Activities
                        .Include(a => a.ActType)
                        .Include(a => a.Leader)
                       orderby a.actName descending
                        select new
                        {
                            Name = a.actName,
                            Description = a.actDescription,
                            Code = a.actCode,
                            Requirement = a.actRequirement,
                            Place = a.actAvailablePlace,
                            Leader = a.Leader.FullName,
                            ActType = a.ActType.acttypeName
                        };
            //How many rows?
            int numRows = acts.Count();

            if (numRows > 0) //We have data
            {
                //Create a new spreadsheet from scratch.
                ExcelPackage excel = new ExcelPackage();

                //Note: you can also pull a spreadsheet out of the database if you
                //have saved it in the normal way we do, as a Byte Array in a Model
                //such as the AFile class.
                //
                // Suppose...
                //
                // var theSpreadsheet = _context.Files.Include(f => f.FileContent).Where(f => f.ID == id).SingleOrDefault();
                //
                //    //Pass the Byte[] FileContent to a MemoryStream
                //
                // using (MemoryStream memStream = new MemoryStream(theSpreadsheet.FileContent.Content))
                // {
                //     ExcelPackage package = new ExcelPackage(memStream);
                // }

                var workSheet = excel.Workbook.Worksheets.Add("Activities");

                //Note: Cells[row, column]
                workSheet.Cells[3, 1].LoadFromCollection(acts, true);

                //Style first column for dates
                //workSheet.Column(1).Style.Numberformat.Format = "yyyy-mm-dd";

                //Style fee column for currency
                //workSheet.Column(4).Style.Numberformat.Format = "###,##0.00";

                //Note: You can define a BLOCK of cells: Cells[startRow, startColumn, endRow, endColumn]
                //Make Date and Patient Bold
                //workSheet.Cells[4, 1, numRows + 3, 2].Style.Font.Bold = true;

                //Note: these are fine if you are only 'doing' one thing to the range of cells.
                //Otherwise you should USE a range object for efficiency
                /*using (ExcelRange totalfees = workSheet.Cells[numRows + 4, 4])//
                {
                    totalfees.Formula = "Sum(" + workSheet.Cells[4, 4].Address + ":" + workSheet.Cells[numRows + 3, 4].Address + ")";
                    totalfees.Style.Font.Bold = true;
                    totalfees.Style.Numberformat.Format = "$###,##0.00";
                }*/

                //Set Style and backgound colour of headings
                using (ExcelRange headings = workSheet.Cells[3, 1, 3, 7])
                {
                    headings.Style.Font.Bold = true;
                    var fill = headings.Style.Fill;
                    fill.PatternType = ExcelFillStyle.Solid;
                    fill.BackgroundColor.SetColor(Color.LightBlue);
                }

                ////Boy those notes are BIG!
                ////Lets put them in comments instead.
                //for (int i = 4; i < numRows + 4; i++)
                //{
                //    using (ExcelRange Rng = workSheet.Cells[i, 7])
                //    {
                //        string[] commentWords = Rng.Value.ToString().Split(' ');
                //        Rng.Value = commentWords[0] + "...";
                //        //This LINQ adds a newline every 7 words
                //        string comment= string.Join(Environment.NewLine, commentWords
                //            .Select((word, index) => new { word, index })
                //            .GroupBy(x => x.index / 7)
                //            .Select(grp => string.Join(" ", grp.Select(x => x.word))));
                //        ExcelComment cmd = Rng.AddComment(comment, "Apt. Notes");
                //        cmd.AutoFit = true;
                //    }
                //}

                //Autofit columns
                workSheet.Cells.AutoFitColumns();
                //Note: You can manually set width of columns as well
                //workSheet.Column(7).Width = 10;

                //Add a title and timestamp at the top of the report
                workSheet.Cells[1, 1].Value = "Activity Report";
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

                //Ok, time to download the Excel
                //Note: if our method was set to return a FileContentResult 
                //      or IActionResult, we could do this:

                //Byte[] theData = excel.GetAsByteArray();
                //string filename = "Appointments.xlsx";
                //string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //return File(theData, mimeType, filename);

                //However, I usually stream the response back to avoid possible
                //out of memory errors on the server if you have a large spreadsheet.

                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.Headers["content-disposition"] = "attachment;  filename=Activities.xlsx";
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
            if (workSheet.Cells[1, 1].Text == "Activity Report")
            {
                for (int row = start.Row + 3; row <= end.Row; row++)
                {
                    // Row by row...
                    Activities a = new Activities
                    {
                        actName = workSheet.Cells[row, 1].Text,
                        actDescription = workSheet.Cells[row, 2].Text,
                        actCode = workSheet.Cells[row, 3].Text,
                        actRequirement = workSheet.Cells[row, 4].Text,
                        actAvailablePlace = workSheet.Cells[row, 5].Text,
                        LeaderID = _context.Leaders.FirstOrDefault(l => l.FullName == workSheet.Cells[row, 6].Text || l.leaderFName == workSheet.Cells[row, 6].Text || l.leaderMName == workSheet.Cells[row, 6].Text || l.leaderLName == workSheet.Cells[row, 6].Text).ID,
                        ActTypeID = _context.ActTypes.FirstOrDefault(at => at.acttypeName == workSheet.Cells[row, 7].Text).ID
                    };
                    if (_context.Activities.Where(act => act.actName == a.actName && act.actCode == a.actCode).FirstOrDefault() == null)
                    {
                        _context.Activities.Add(a);
                    }
                };
            }
            else
            {
                for (int row = start.Row; row <= end.Row; row++)
                {
                    // Row by row...
                    Activities a = new Activities
                    {
                        actName = workSheet.Cells[row, 1].Text,
                        actDescription = workSheet.Cells[row, 2].Text,
                        actCode = workSheet.Cells[row, 3].Text,
                        actRequirement = workSheet.Cells[row, 4].Text,
                        actAvailablePlace = workSheet.Cells[row, 5].Text,
                        LeaderID = _context.Leaders.FirstOrDefault(l => l.FullName == workSheet.Cells[row, 6].Text || l.leaderFName == workSheet.Cells[row, 6].Text || l.leaderMName == workSheet.Cells[row, 6].Text || l.leaderLName == workSheet.Cells[row, 6].Text).ID,
                        ActTypeID = _context.ActTypes.FirstOrDefault(at => at.acttypeName == workSheet.Cells[row, 7].Text).ID
                    };
                    if (_context.Activities.Where(act => act.actName == a.actName && act.actCode == a.actCode).FirstOrDefault() == null)
                    {
                        _context.Activities.Add(a);
                    }
                };
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool ActivitysExists(int id)
        {
            return _context.Activities.Any(e => e.ID == id);
        }
    }
}
