using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BnGClub.Data;
using BnGClub.Models;
using WebPush;
using Microsoft.EntityFrameworkCore;

namespace BnGClub.Controllers
{
    public class WebPushController : Controller
    {
        private readonly BnGClubContext _context;
        private readonly IConfiguration _configuration;

        public WebPushController(BnGClubContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Send(int? id, string SubName)
        {
            ViewData["SubName"] = SubName;
            return View();
        }

        [HttpPost, ActionName("Send")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(int id, string payload)
        {
            var subcriptions = await _context.Subscriptions.SingleOrDefaultAsync(m => m.ID == id);

            string vapidPublicKey = _configuration.GetSection("VapidKeys")["PublicKey"];
            string vapidPrivateKey = _configuration.GetSection("VapidKeys")["PrivateKey"];
            var vapidDetails = new VapidDetails("mailto:youremail@example.com", vapidPublicKey, vapidPrivateKey);

            var pushSubscription = new PushSubscription(subcriptions.PushEndpoint, subcriptions.PushP256DH, subcriptions.PushAuth);

            try
            {
                var webPushClient = new WebPushClient();
                webPushClient.SendNotification(pushSubscription, payload, vapidDetails);
            }
            catch (WebPushException ex)
            {
                var statusCode = ex.StatusCode;
                return new StatusCodeResult((int)statusCode);
            }

            return View();
        }

        public IActionResult GenerateKeys()
        {
            var keys = VapidHelper.GenerateVapidKeys();

            ViewBag.PublicKey = keys.PublicKey;
            ViewBag.PrivateKey = keys.PrivateKey;

            return View();
        }
    }
}