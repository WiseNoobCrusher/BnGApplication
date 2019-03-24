using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using BnGClub.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace BnGClub.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly BnGClubContext _context;

        public ChildrenController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: Children
        public async Task<IActionResult> Index()
        {
            var children = from c in _context.Childs
                           .Include(c => c.User)
                           .Include(c => c.ChildEnrolleds).ThenInclude(c => c.Activities)
                           select c;

            if (User.IsInRole("Parent"))
            {
                int UserID = _context.Users.FirstOrDefault(u => u.userEmail == User.Identity.Name).ID;
                children = children.Where(c => c.UserID == UserID);
            }

            return View(await children.ToListAsync());
        }

        // GET: Children/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Childs
                .Include(c => c.User)
                .Include(c => c.ChildEnrolleds).ThenInclude(c => c.Activities)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // GET: Children/Create
        public IActionResult Create()
        {
            Child child = new Child();
            PopulateAssignedActivityData(child);
            PopulateDropDownLists();
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,childFName,childMName,childLName,childDOB,UserID")] Child child, string[] selectedOptions)
        {
            try
            {
                UpdateChildActivities(selectedOptions, child);
                if (ModelState.IsValid)
                {
                    _context.Add(child);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateAssignedActivityData(child);
            PopulateDropDownLists(child);
            return View(child);
        }

        // GET: Children/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Childs
                .Include(c => c.User)
                .Include(c => c.ChildEnrolleds).ThenInclude(c => c.Activities)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.ID == id);

            if (child == null)
            {
                return NotFound();
            }

            PopulateAssignedActivityData(child);
            PopulateDropDownLists(child);
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,childFName,childMName,childLName,childDOB,UserID")] Child child, string[] selectedOptions)
        {
            var childToUpdate = await _context.Childs
                .Include(c => c.User)
                .Include(c => c.ChildEnrolleds).ThenInclude(c => c.Activities)
                .SingleOrDefaultAsync(c => c.ID == id);

            if (childToUpdate == null)
            {
                return NotFound();
            }

            UpdateChildActivities(selectedOptions, childToUpdate);

            if (await TryUpdateModelAsync<Child>(childToUpdate, "", 
                c => c.childFName, c => c.childMName, c => c.childLName, c => c.childDOB))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildExists(childToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateAssignedActivityData(childToUpdate);
            PopulateDropDownLists(childToUpdate);
            return View(childToUpdate);
        }

        // GET: Children/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Childs
                .Include(c => c.User)
                .Include(c => c.ChildEnrolleds).ThenInclude(c => c.Activities)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var child = await _context.Childs
                .Include(c => c.User)
                .Include(c => c.ChildEnrolleds).ThenInclude(c => c.Activities)
                .FirstOrDefaultAsync(m => m.ID == id);

            UpdateChildActivities(null, child);

            _context.Childs.Remove(child);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList UserSelectList(int? id)
        {
            var dQuery = from d in _context.Users
                         orderby d.userFName
                         select d;
            return new SelectList(dQuery, "ID", "FullName", id);
        }

        private void PopulateDropDownLists(Child child = null)
        {
            ViewData["UserID"] = UserSelectList(child?.UserID);
        }

        private void PopulateAssignedActivityData(Child child)
        {
            var allActivities = _context.Activities;
            var childActivities = new HashSet<int>(child.ChildEnrolleds.Select(e => e.ActID));
            var selected = new List<ActivityVM>();
            var available = new List<ActivityVM>();
            foreach (var a in allActivities)
            {
                if (childActivities.Contains(a.ID))
                {
                    selected.Add(new ActivityVM
                    {
                        ActivityID = a.ID,
                        Name = a.actName
                    });
                }
                else
                {
                    available.Add(new ActivityVM
                    {
                        ActivityID = a.ID,
                        Name = a.actName
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(a => a.Name), "ActivityID", "Name");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(a => a.Name), "ActivityID", "Name");
        }

        private void UpdateChildActivities(string[] selectedOptions, Child childToUpdate)
        {
            if (selectedOptions == null)
            {
                childToUpdate.ChildEnrolleds = new List<childEnrolled>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var childActivities = new HashSet<int>(childToUpdate.ChildEnrolleds.Select(e => e.ActID));
            foreach (var a in _context.Activities)
            {
                if (selectedOptionsHS.Contains(a.ID.ToString()))
                {
                    if (!childActivities.Contains(a.ID))
                    {
                        childToUpdate.ChildEnrolleds.Add(new childEnrolled
                        {
                            ActID = a.ID,
                            ChildID = childToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (childActivities.Contains(a.ID))
                    {
                        childEnrolled specToRemove = childToUpdate.ChildEnrolleds.SingleOrDefault(e => e.ActID == a.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }

        private bool ChildExists(int id)
        {
            return _context.Childs.Any(e => e.ID == id);
        }
    }
}
