using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcW03.Entities;

namespace MvcW03.DataAccess.EntityFramework
{
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; initial catalog=School;  Trusted_Connection=True; ");
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
