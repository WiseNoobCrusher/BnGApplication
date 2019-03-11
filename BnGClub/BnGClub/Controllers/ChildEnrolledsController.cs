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
    public class ChildEnrolledsController : Controller
    {
        private readonly BnGClubContext _context;

        public ChildEnrolledsController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: ChildEnrolleds
        public async Task<IActionResult> Index()
        {
            var bnGClubContext = _context.childEnrolleds.Include(c => c.Activitys).Include(c => c.Child);
            return View(await bnGClubContext.ToListAsync());
        }

        // GET: ChildEnrolleds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childEnrolled = await _context.childEnrolleds
                .Include(c => c.Activitys)
                .Include(c => c.Child)
                .FirstOrDefaultAsync(m => m.actID == id);
            if (childEnrolled == null)
            {
                return NotFound();
            }

            return View(childEnrolled);
        }

        // GET: ChildEnrolleds/Create
        public IActionResult Create()
        {
            ViewData["id"] = new SelectList(_context.Activities, "id", "acttypeName");
            ViewData["id"] = new SelectList(_context.Childs, "id", "FullName");
            return View();
        }

        // POST: ChildEnrolleds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,actID,childID")] childEnrolled childEnrolled)
        {
            if (ModelState.IsValid)
            {
                _context.Add(childEnrolled);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = new SelectList(_context.Activities, "id", "acttypeName", childEnrolled.id);
            ViewData["id"] = new SelectList(_context.Childs, "id", "FullName", childEnrolled.id);
            return View(childEnrolled);
        }

        // GET: ChildEnrolleds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childEnrolled = await _context.childEnrolleds.FindAsync(id);
            if (childEnrolled == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.Activities, "id", "acttypeName", childEnrolled.id);
            ViewData["id"] = new SelectList(_context.Childs, "id", "FullName", childEnrolled.id);
            return View(childEnrolled);
        }

        // POST: ChildEnrolleds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,actID,childID")] childEnrolled childEnrolled)
        {
            if (id != childEnrolled.actID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(childEnrolled);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!childEnrolledExists(childEnrolled.actID))
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
            ViewData["id"] = new SelectList(_context.Activities, "id", "acttypeName", childEnrolled.id);
            ViewData["id"] = new SelectList(_context.Childs, "id", "FullName", childEnrolled.id);
            return View(childEnrolled);
        }

        // GET: ChildEnrolleds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childEnrolled = await _context.childEnrolleds
                .Include(c => c.Activitys)
                .Include(c => c.Child)
                .FirstOrDefaultAsync(m => m.actID == id);
            if (childEnrolled == null)
            {
                return NotFound();
            }

            return View(childEnrolled);
        }

        // POST: ChildEnrolleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var childEnrolled = await _context.childEnrolleds.FindAsync(id);
            _context.childEnrolleds.Remove(childEnrolled);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool childEnrolledExists(int id)
        {
            return _context.childEnrolleds.Any(e => e.actID == id);
        }
    }
}
