using EventProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Controllers
{
    public class ContactController : Controller
    {
        DataContext db = new DataContext();

        // GET: Contact
        public ActionResult Index()
        {
            Contacts model = db.Contacts.FirstOrDefault();
            return View(model);

        }

        [HttpPost]
        public ActionResult Index (Contacts model)
        {
          
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.live.com";

            smtp.Port = 587;

            smtp.EnableSsl = true;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


            if (model != null)
            {
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("LykkeReinholdtOlesen@live.dk", "lullu1234");

            MailMessage message = new MailMessage();

            message.To.Add(new MailAddress("LykkeReinholdtOlesen@live.dk"));
            message.From = new MailAddress(model.Email);
            message.Subject = "Du har modtaget en mail fra: " + model.Navn + "<" + model.Email + ">";
            message.Body = model.Besked;

            message.IsBodyHtml = true;

            smtp.Send(message);

            TempData["Message"] = "Din besked er sendt";

            }


            return RedirectToAction("Index");
        }
    }
}