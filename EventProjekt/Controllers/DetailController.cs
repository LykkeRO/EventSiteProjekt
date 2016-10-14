using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Controllers
{
    public class DetailController : Controller
    {
        DataContext db = new DataContext();
        // GET: Detalje
        public ActionResult Index(int id)
        {
            Event model = db.Events.Where(t => t.Id == id).FirstOrDefault();
     
            return View(model);
        }
    }
}