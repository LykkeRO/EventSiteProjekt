using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {

           List<Event> e = db.Events.ToList(); 
            
            return View(e);
        }


    }
}