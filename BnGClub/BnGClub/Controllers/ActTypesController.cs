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
    public class ActTypesController : Controller
    {
        private readonly BnGClubContext _context;

        public ActTypesController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: ActTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActTypes.ToListAsync());
        }

        // GET: ActTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (actType == null)
            {
                return NotFound();
            }

            return View(actType);
        }

        // GET: ActTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,acttypeName,acttypeDescription")] ActType actType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actType);
        }

        // GET: ActTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActTypes.FindAsync(id);
            if (actType == null)
            {
                return NotFound();
            }
            return View(actType);
        }

        // POST: ActTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,acttypeName,acttypeDescription")] ActType actType)
        {
            if (id != actType.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActTypeExists(actType.id))
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
            return View(actType);
        }

        // GET: ActTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actType = await _context.ActTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (actType == null)
            {
                return NotFound();
            }

            return View(actType);
        }

        // POST: ActTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actType = await _context.ActTypes.FindAsync(id);
            _context.ActTypes.Remove(actType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActTypeExists(int id)
        {
            return _context.ActTypes.Any(e => e.id == id);
        }
    }
}
