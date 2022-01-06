using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolContext()
            : base()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        //}
    }
}
