using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventProjekt.Models
{
    public class ContactViewModel
    {
        public Contacts contact { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Besked { get; set; }

    }
}