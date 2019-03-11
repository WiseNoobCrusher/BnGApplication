using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using BnGClub.Utilities;

namespace BnGClub.Controllers
{
    public class LeadersProfileController : Controller
    {
        private readonly BnGClubContext _context;

        public LeadersProfileController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: LeadersProfile
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Details));
        }

        // GET: LeadersProfile/Details/5
        public async Task<IActionResult> Details()
        {

            var leader = await _context.Leaders
                .Where(l => l.leaderEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (leader == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(leader);
        }

        // GET: LeadersProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeadersProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,leaderFName,leaderMName,leaderLName,leaderEmail,leaderPhone")] Leader leader)
        {
            leader.leaderEmail = User.Identity.Name;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(leader);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(leader.FullName);
                    return RedirectToAction(nameof(Details));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(leader);
        }

        // GET: LeadersProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await _context.Leaders
                .Where(l => l.leaderEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (leader == null)
            {
                return NotFound();
            }
            return View(leader);
        }

        // POST: LeadersProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var leaderToUpdate = await _context.Leaders
                .FirstOrDefaultAsync(l => l.id == id);

            if (await TryUpdateModelAsync<Leader>(leaderToUpdate, "",
                l => l.leaderFName, l => l.leaderMName, l => l.leaderLName, l => l.leaderPhone, l => l.leaderEmail))
            {
                try
                {
                    //Put the original RowVersion value in the OriginalValues collection for the entity
                    _context.Update(leaderToUpdate);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(leaderToUpdate.FullName);
                    return RedirectToAction(nameof(Details));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderExists(leaderToUpdate.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. The record you attempted to edit "
                                + "was modified by another user after you received your values.  You need to go back and try your edit again.");
                    }
                }
            }
            return View(leaderToUpdate);
        }

        // GET: LeadersProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = await _context.Leaders
                .FirstOrDefaultAsync(m => m.id == id);
            if (leader == null)
            {
                return NotFound();
            }

            return View(leader);
        }

        // POST: LeadersProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leader = await _context.Leaders.FindAsync(id);
            _context.Leaders.Remove(leader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void UpdateUserNameCookie(string userName)
        {
            CookieHelper.CookieSet(HttpContext, "userName", userName, 960);
        }

        private bool LeaderExists(int id)
        {
            return _context.Leaders.Any(e => e.id == id);
        }
    }
}
