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
    public class UsersProfileController : Controller
    {
        private readonly BnGClubContext _context;

        public UsersProfileController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: UsersProfile
        public async Task<IActionResult> Index()
        {
            return RedirectToAction(nameof(Details));
        }

        // GET: UsersProfile/Details/5
        public async Task<IActionResult> Details()
        {

            var user = await _context.Users
                .Where(u => u.userEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(user);
        }

        // GET: UsersProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userFName,userMName,userLName,userEmail,userPhone")] User user)
        {
            user.userEmail = User.Identity.Name;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(user.FullName);
                    return RedirectToAction(nameof(Details));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(user);
        }

        // GET: UsersProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Where(u => u.userEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UsersProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var userToUpdate = await _context.Users
                .FirstOrDefaultAsync(u => u.id == id);

            if (await TryUpdateModelAsync<User>(userToUpdate, "",
                u => u.userFName, u => u.userMName, u => u.userLName, u => u.userPhone))
            {
                try
                {
                    //Put the original RowVersion value in the OriginalValues collection for the entity
                    _context.Update(userToUpdate);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(userToUpdate.FullName);
                    return RedirectToAction(nameof(Details));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userToUpdate.id))
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
            return View(userToUpdate);
        }

        // GET: UsersProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UsersProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void UpdateUserNameCookie(string userName)
        {
            CookieHelper.CookieSet(HttpContext, "userName", userName, 960);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
