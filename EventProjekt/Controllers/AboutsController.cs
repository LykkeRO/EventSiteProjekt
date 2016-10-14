using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Controllers
{
    public class AboutsController : Controller
    {
        DataContext db = new DataContext();
        // GET: OmAarthusEvents
        public ActionResult Index()
        {

           About model = db.Abouts.FirstOrDefault();
            return View(model);
        }
    }
}