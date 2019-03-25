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
    public class LeadersController : Controller
    {
        private readonly BnGClubContext _context;

        public LeadersController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: Leaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leaders.ToListAsync());
        }

        // GET: Leaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await _context.Leaders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leader == null)
            {
                return NotFound();
            }

            return View(leader);
        }

        // GET: Leaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,leaderFName,leaderMName,leaderLName,leaderEmail,leaderPhone")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leader);
        }

        // GET: Leaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await _context.Leaders.FindAsync(id);
            if (leader == null)
            {
                return NotFound();
            }
            return View(leader);
        }

        // POST: Leaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,leaderFName,leaderMName,leaderLName,leaderEmail,leaderPhone")] Leader leader)
        {
            if (id != leader.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderExists(leader.ID))
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
            return View(leader);
        }

        // GET: Leaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await _context.Leaders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leader == null)
            {
                return NotFound();
            }

            return View(leader);
        }

        // POST: Leaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leader = await _context.Leaders.FindAsync(id);
            _context.Leaders.Remove(leader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaderExists(int id)
        {
            return _context.Leaders.Any(e => e.ID == id);
        }
    }
}
