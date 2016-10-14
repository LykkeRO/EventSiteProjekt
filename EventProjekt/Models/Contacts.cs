using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventProjekt.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string EfterNavn { get; set; }
        public string Adresse { get; set; }
        public string Bynavn { get; set; }
        public int Postnummer { get; set; }
        public int Tlf { get; set; }

        [EmailAddress]
        [Display(Name = "Din Email")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Besked { get; set; }
    }
}