using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC9909.Models
{
    public class ABCDBContext: DbContext
    {
        public ABCDBContext() : base("ABCConStr")
        {

        }

        public DbSet <room> rooms { get; set; }
        public DbSet<student> students { get; set; }
        public DbSet<teacher> teachers { get; set; }
        public DbSet<course> courses { get; set; }

    }
}