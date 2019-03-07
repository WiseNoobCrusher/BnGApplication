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
    public class ActivitysController : Controller
    {
        private readonly BnGClubContext _context;

        public ActivitysController(BnGClubContext context)
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
                .FirstOrDefaultAsync(m => m.id == id);
            if (activitys == null)
            {
                return NotFound();
            }

            return View(activitys);
        }

        // GET: Activitys/Create
        public IActionResult Create()
        {
            ViewData["id"] = new SelectList(_context.ActTypes, "id", "acttypeDescription");
            ViewData["id"] = new SelectList(_context.Leaders, "id", "leaderEmail");
            return View();
        }

        // POST: Activitys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,actName,actDescription,actCode,actRequirement,actAvailablePlace,leaderID,acttypeID")] Activitys activitys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activitys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = new SelectList(_context.ActTypes, "id", "acttypeDescription", activitys.id);
            ViewData["id"] = new SelectList(_context.Leaders, "id", "leaderEmail", activitys.id);
            return View(activitys);
        }

        // GET: Activitys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitys = await _context.Activities.FindAsync(id);
            if (activitys == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.ActTypes, "id", "acttypeDescription", activitys.id);
            ViewData["id"] = new SelectList(_context.Leaders, "id", "leaderEmail", activitys.id);
            return View(activitys);
        }

        // POST: Activitys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,actName,actDescription,actCode,actRequirement,actAvailablePlace,leaderID,acttypeID")] Activitys activitys)
        {
            if (id != activitys.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activitys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitysExists(activitys.id))
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
            ViewData["id"] = new SelectList(_context.ActTypes, "id", "acttypeDescription", activitys.id);
            ViewData["id"] = new SelectList(_context.Leaders, "id", "leaderEmail", activitys.id);
            return View(activitys);
        }

        // GET: Activitys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitys = await _context.Activities
                .Include(a => a.ActType)
                .Include(a => a.Leader)
                .FirstOrDefaultAsync(m => m.id == id);
            if (activitys == null)
            {
                return NotFound();
            }

            return View(activitys);
        }

        // POST: Activitys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activitys = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(activitys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitysExists(int id)
        {
            return _context.Activities.Any(e => e.id == id);
        }
    }
}
