using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using System.Diagnostics;

namespace BnGClub.Controllers
{
    public class MessagesController : Controller
    {
        private readonly BnGClubContext _context;

        public MessagesController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index(string recip)
        {
            var messages = from m in _context.Messages
                           select m;

            if (User.IsInRole("Parent"))
            {
                string userName = _context.Users.FirstOrDefault(u => u.userEmail == User.Identity.Name).FullName;
                messages = messages.Where(m => m.msgTo == userName || m.msgFrom == userName).OrderBy(m => m.CreatedOn);
            }
            else if (User.IsInRole("Instructor"))
            {
                string leaderName = _context.Leaders.FirstOrDefault(l => l.leaderEmail == User.Identity.Name).FullName;
                messages = messages.Where(m => m.msgTo == leaderName || m.msgFrom == leaderName).OrderBy(m => m.CreatedOn);
            }

            if (recip != null)
            {
                if (User.IsInRole("Parent"))
                {
                    string userName = _context.Users.FirstOrDefault(u => u.userEmail == User.Identity.Name).FullName;
                    messages = messages.Where(m => m.msgTo == recip && m.msgFrom == userName || m.msgTo == userName && m.msgFrom == recip).OrderBy(m => m.CreatedOn);
                }
                else if (User.IsInRole("Instructor"))
                {
                    string leaderName = _context.Leaders.FirstOrDefault(l => l.leaderEmail == User.Identity.Name).FullName;
                    string userName = _context.Users.FirstOrDefault(u => u.ID == Convert.ToInt32(recip)).FullName;
                    messages = messages.Where(m => m.msgTo == userName && m.msgFrom == leaderName || m.msgTo == leaderName && m.msgFrom == userName).OrderBy(m => m.CreatedOn);
                }
            }

            PopulateDropDownLists();

            return View(await messages.ToListAsync());
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create(string recip, int? leader)
        {
            if (User.IsInRole("Parent"))
            {
                ViewData["MsgTo"] = recip;
                ViewData["MsgFrom"] = _context.Users.FirstOrDefault(u => u.userEmail == User.Identity.Name).FullName;
            }
            else if (User.IsInRole("Instructor"))
            {
                ViewData["MsgTo"] = _context.Users.FirstOrDefault(u => u.ID == leader).FullName;
                ViewData["MsgFrom"] = _context.Leaders.FirstOrDefault(l => l.leaderEmail == User.Identity.Name).FullName;
            }

            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,msgTo,msgFrom,msgBody")] Message message)
        {
            if (User.IsInRole("Parent"))
            {
                message.msgFrom = _context.Users.FirstOrDefault(u => u.userEmail == User.Identity.Name).FullName;
            }
            else if (User.IsInRole("Instructor"))
            {
                message.msgFrom = _context.Leaders.FirstOrDefault(l => l.leaderEmail == User.Identity.Name).FullName;
            }

            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,msgTo,msgFrom,msgBody")] Message message, Byte[] RowVersion)
        {
            if (id != message.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(message).Property("RowVersion").OriginalValue = RowVersion;
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Message)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Message was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Message)databaseEntry.ToObject();
                        if (databaseValues.msgTo != clientValues.msgTo)
                            ModelState.AddModelError("msgTo", "Current value: "
                                + databaseValues.msgTo);
                        if (databaseValues.msgFrom != clientValues.msgFrom)
                            ModelState.AddModelError("msgFrom", "Current value: "
                                + databaseValues.msgFrom);
                        if (databaseValues.msgBody != clientValues.msgBody)
                            ModelState.AddModelError("msgBody", "Current value: "
                                + databaseValues.msgBody);
                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                            + "was modified by another user after you received your values. The "
                            + "edit operation was canceled and the current values in the database "
                            + "have been displayed. If you still want to save your version of this record, click "
                            + "the Save button again. Otherwise, click the 'Back to List' hyperlink.");
                        message.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.ID == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList ToSelectList()
        {
            if (User.IsInRole("Parent"))
            {
                var dQuery = from d in _context.Leaders
                             orderby d.leaderFName
                             select d;
                return new SelectList(dQuery, "FullName", "FullName");
            }
            else if (User.IsInRole("Instructor"))
            {
                var dQuery = from d in _context.Users
                             orderby d.userFName
                             select d;
                return new SelectList(dQuery, "ID", "FullName");
            }
            else
            {
                return null;
            }
        }

        private void PopulateDropDownLists()
        {
            ViewData["RecipientID"] = ToSelectList();
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.ID == id);
        }
    }
}
