﻿using System;
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
    public class LeaderMessagesController : Controller
    {
        private readonly BnGClubContext _context;

        public LeaderMessagesController(BnGClubContext context)
        {
            _context = context;
        }

        // GET: LeaderMessages
        public async Task<IActionResult> Index()
        {
            var bnGClubContext = _context.LeaderMessages.Include(l => l.Leader);
            return View(await bnGClubContext.ToListAsync());
        }

        // GET: LeaderMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderMessage = await _context.LeaderMessages
                .Include(l => l.Leader)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leaderMessage == null)
            {
                return NotFound();
            }

            return View(leaderMessage);
        }

        // GET: LeaderMessages/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: LeaderMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,msgDate,msgDescription,LeaderID")] LeaderMessage leaderMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaderMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(leaderMessage);
            return View(leaderMessage);
        }

        // GET: LeaderMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderMessage = await _context.LeaderMessages.FindAsync(id);
            if (leaderMessage == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(leaderMessage);
            return View(leaderMessage);
        }

        // POST: LeaderMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,msgDate,msgDescription,leaderID")] LeaderMessage leaderMessage)
        {
            if (id != leaderMessage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaderMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaderMessageExists(leaderMessage.ID))
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
            PopulateDropDownLists(leaderMessage);
            return View(leaderMessage);
        }

        // GET: LeaderMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaderMessage = await _context.LeaderMessages
                .Include(l => l.Leader)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leaderMessage == null)
            {
                return NotFound();
            }

            return View(leaderMessage);
        }

        // POST: LeaderMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaderMessage = await _context.LeaderMessages.FindAsync(id);
            _context.LeaderMessages.Remove(leaderMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private SelectList LeaderSelectList(int? id)
        {
            var dQuery = from d in _context.Leaders
                         orderby d.leaderFName
                         select d;
            return new SelectList(dQuery, "ID", "FullName", id);
        }

        private void PopulateDropDownLists(LeaderMessage leaderMessage = null)
        {
            ViewData["LeaderID"] = LeaderSelectList(leaderMessage?.LeaderID);
        }

        private bool LeaderMessageExists(int id)
        {
            return _context.LeaderMessages.Any(e => e.ID == id);
        }
    }
}