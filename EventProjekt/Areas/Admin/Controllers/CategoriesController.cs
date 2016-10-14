using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {

        DataContext db = new DataContext();

        // GET: Admin/Categories
        public ActionResult Index()
        {

            var cat = db.Categories;
            return View(cat.ToList()); 
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Navn");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public ActionResult Edit (int? id)
        {

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Category cat = db.Categories.Find(id);
             
            if(cat == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {

            if (ModelState.IsValid)
            {

                db.Entry(cat).State = EntityState.Modified;

                TempData["Message"] = "Din ændring er nu foretaget";

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat = new SelectList(db.Categories, "Id", "Name");

            TempData["Message"] = "Der opstod en fejl under ændringen";

            return View(cat);

        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category cat = db.Categories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int id)
        {

            Category cat = db.Categories.Find(id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}