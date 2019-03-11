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

        private bool ActivitysExists(int id)
        {
            return _context.Activities.Any(e => e.ID == id);
        }
    }
}
