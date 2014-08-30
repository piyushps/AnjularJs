using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AnjularCrud.Operation.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name = DefaultConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Student { get; set; }
    }
}