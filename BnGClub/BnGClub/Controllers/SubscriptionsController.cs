using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BnGClub.Data;
using BnGClub.Models;
using Microsoft.Extensions.Configuration;

namespace BnGClub.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly BnGClubContext _context;
        private readonly IConfiguration _configuration;

        public SubscriptionsController(BnGClubContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            var bnGClubContext = _context.Subscriptions.Include(s => s.User);

            string PK = _configuration.GetSection("VapidKeys")["PublicKey"];
            if (String.IsNullOrEmpty(PK))
            {
                return RedirectToAction("GenerateKeys", "WebPush");
            }

            return View(await bnGClubContext.ToListAsync());
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptions = await _context.Subscriptions
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriptions == null)
            {
                return NotFound();
            }

            return View(subscriptions);
        }

        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "userEmail");
            ViewBag.PublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,PushEndpoint,PushP256DH,PushAuth,UserID")] Subscriptions subscriptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "userEmail", subscriptions.UserID);
            return View(subscriptions);
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptions = await _context.Subscriptions.FindAsync(id);
            if (subscriptions == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "userEmail", subscriptions.UserID);
            return View(subscriptions);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,PushEndpoint,PushP256DH,PushAuth,UserID")] Subscriptions subscriptions)
        {
            if (id != subscriptions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionsExists(subscriptions.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "userEmail", subscriptions.UserID);
            return View(subscriptions);
        }

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptions = await _context.Subscriptions
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriptions == null)
            {
                return NotFound();
            }

            return View(subscriptions);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriptions = await _context.Subscriptions.FindAsync(id);
            _context.Subscriptions.Remove(subscriptions);
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

        private void PopulateDropDownLists(Subscriptions subs = null)
        {
            ViewData["UserID"] = UserSelectList(subs?.UserID);
        }

        private bool SubscriptionsExists(int id)
        {
            return _context.Subscriptions.Any(e => e.ID == id);
        }
    }
}
