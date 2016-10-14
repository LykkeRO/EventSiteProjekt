using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Controllers
{
   

    public class EventsController : Controller
    {
        DataContext db = new DataContext();


        // GET: Events
        public ActionResult Index()
        {
            List<Event> model = db.Events.ToList();

                        
            return View(model);
        }


        [HttpGet]
        public ActionResult GetById(int Id)
        {

            Event events = db.Events.Where(c => c.Id == Id).FirstOrDefault();

            if (events == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View(events);
        }

        
        public ActionResult GetEventsByName(string name, string cat)
        {
            var data = db.Events.Where(p => name != null ? p.Navn.Contains(name) : true).ToList();
            return View(data);


        }


    }
}