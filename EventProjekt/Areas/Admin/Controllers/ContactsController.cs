using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Areas.Admin.Controllers
{
    public class ContactsController : Controller
    {
        DataContext db = new DataContext();

        // GET: Admin/Contact
        public ActionResult Index()
        {
            Contacts contact = db.Contacts.FirstOrDefault();

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Contacts contact)
        {

            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Din ændring er nu foretaget";
                return RedirectToAction("Index");

            }
            TempData["Message"] = "Der opstod en fejl under ændringen";
            return View(contact);



        }
    }
}