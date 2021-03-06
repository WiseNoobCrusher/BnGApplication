﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using Microsoft.Extensions.Configuration;
using BnGClub.Utilities;

namespace BnGClub.Controllers
{
    public class UsersProfileController : Controller
    {
        private readonly BnGClubContext _context;
        private readonly IConfiguration _configuration;

        public UsersProfileController(BnGClubContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: UsersProfile
        public async Task<IActionResult> Index()
        {
            return RedirectToAction(nameof(Details));
        }

        // GET: UsersProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var users = await _context.Users
                .Where(u => u.userEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (users == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(users);
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
        public async Task<IActionResult> Create([Bind("ID,userFName,userMName,userLName,userEmail,userPhone,notificationOptIn")] Users users)
        {
            users.userEmail = User.Identity.Name;
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(users);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(users.FullName);
                    return LocalRedirect("/Children/Create");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(users);
        }

        // GET: UsersProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Where(u => u.userEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (users == null)
            {
                return NotFound();
            }

            ViewBag.PublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            return View(users);
        }

        // POST: UsersProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string PushEndpoint, string PushP256DH, string PushAuth, bool notifications)
        {
            var usersToUpdate = await _context.Users
                .FirstOrDefaultAsync(u => u.ID == id);

            AddToNotifications(id, PushEndpoint, PushP256DH, PushAuth, notifications, usersToUpdate);

            if (await TryUpdateModelAsync<Users>(usersToUpdate, "",
                u => u.userFName, u => u.userMName, u => u.userLName, u => u.userPhone, u => u.notificationOptIn))
            {
                try
                {
                    //Put the original RowVersion value in the OriginalValues collection for the entity
                    usersToUpdate.notificationOptIn = notifications;
                    _context.Update(usersToUpdate);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(usersToUpdate.FullName);
                    return RedirectToAction(nameof(Details));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(usersToUpdate.ID))
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
            return View(usersToUpdate);
        }

        // GET: UsersProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: UsersProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void AddToNotifications(int id, string PushEndpoint, string PushP256DH, string PushAuth, bool notifications, Users users)
        {
            var subUserExists = false;

            foreach (var s in _context.Subscriptions)
            {
                if (s.UserID == id)
                {
                    subUserExists = true;
                }
            }

            if (notifications == true)
            {
                if (subUserExists == false)
                {
                    _context.Subscriptions.Add(new Subscriptions
                    {
                        Name = users.FullName,
                        PushEndpoint = PushEndpoint,
                        PushP256DH = PushP256DH,
                        PushAuth = PushAuth,
                        UserID = id
                    });
                }
            }
            else if (notifications == false)
            {
                if (subUserExists == true)
                {
                    Subscriptions subToRemove = _context.Subscriptions.FirstOrDefault(s => s.UserID == id);
                    if (subToRemove != null)
                    {
                        _context.Subscriptions.Remove(subToRemove);
                    }
                }
            }
        }

        private void UpdateUserNameCookie(string userName)
        {
            CookieHelper.CookieSet(HttpContext, "userName", userName, 960);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
