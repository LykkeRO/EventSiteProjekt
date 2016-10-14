using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventProjekt.Models
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Detail> Details { get; set; }

    }
}