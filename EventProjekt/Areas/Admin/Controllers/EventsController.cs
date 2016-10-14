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
    public class EventsController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin/Events


        public ActionResult Index()
        {
            var e = db.Events;
            return View(e.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories, "Id", "Navn");


            return View();
        }

        [HttpPost]
        public ActionResult Create(Event events, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                if (file != null && file.ContentLength > 0)
                {
                    string filename = events.Id + Path.GetExtension(file.FileName);
                    string fullpath = Request.MapPath("~/Content/images/");
                    file.SaveAs(Path.Combine(fullpath, filename));
                    events.Image = filename;

                }
                db.SaveChanges();



                return RedirectToAction("index");
            }

            return View();

        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }

            ViewBag.Events = new SelectList(db.Events, "Id", "Navn");
            return View(events);
        }



        [HttpPost]
        public ActionResult Edit(Event events, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;

                if (file != null && file.ContentLength > 0)
                {

                    string fileName = events.Id + Path.GetExtension(file.FileName);
                    string fullPath = Request.MapPath("~/Content/images/");
                    file.SaveAs(Path.Combine(fullPath, fileName));
                    events.Image = fileName;
                }
                else
                {
                    db.Entry(events).Property(e => e.Image).IsModified = false;
                }

                
                db.SaveChanges();
                TempData["Message"] = "Din ændring er nu foretaget";
                return RedirectToAction("Index");
            }

            ViewBag.Events = new SelectList(db.Events, "Id", "Navn", events.Id);

            TempData["Message"] = "Der opstod en fejl under ændringen";
            return View(events);

        }



        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            }

            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }

            return View(events);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }




    
}