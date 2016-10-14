using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Areas.Admin.Controllers
{
    public class AboutsController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin/About
        public ActionResult Index()
        {
            About about = db.Abouts.FirstOrDefault();
  
            if(about == null)
            {
                about = new About();
                about.Tekst = "";
                db.Abouts.Add(about);
                db.SaveChanges();
            }

            return View(about);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (About about)
        {

            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Message"] = "Din ændring er nu foretaget";

                return RedirectToAction("Index");

            }
            TempData["Message"] = "Der opstod en fejl under ændringen";

            return View(about);



        }

    }
}