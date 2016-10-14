using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventProjekt.Models
{
    public class About
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Tekst { get; set; }
    }
}