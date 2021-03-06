﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BnGClub.Models;
using BnGClub.Data;
using Microsoft.EntityFrameworkCore;

namespace BnGClub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var query = from s in _context.Announcements
            //            where s.AnnouncementsID == id
            //            select s;
            //return PartialView("_ListOfPatients", query.ToList());
            return View();
        }

        //public PartialViewResult ListOfPatientsDetails(int id)
        //{
        //    var query = from s in _context
        //                where s.DoctorID == id
        //                select s;
        //    return PartialView("_ListOfPatients", query.ToList());
        //}
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
