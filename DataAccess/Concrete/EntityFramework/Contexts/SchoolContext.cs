using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; initial catalog=School;  Trusted_Connection=True; ");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaimms { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
