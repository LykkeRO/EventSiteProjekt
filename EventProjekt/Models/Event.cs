using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Navn { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Beskrivelse { get; set; }

        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public decimal Pris { get; set; }
        public string Adresse { get; set; }
        public string Image { get; set; }
        public int KategoriId { get; set; }
    }
}