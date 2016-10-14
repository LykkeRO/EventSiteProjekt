using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Controllers
{
    public class NyhedsController : Controller
    {
        DataContext db = new DataContext();
      
        // GET: Nyheds
        public ActionResult Index()
        {
           
            List<Event> model = db.Events.OrderByDescending(t => t.Id).Take(2).ToList();

            return View(model);
        }
    }
}