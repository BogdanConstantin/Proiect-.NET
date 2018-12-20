using DataAccess.ClassesManagement.Write.Configurations.Entities;
using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ClassesManagement.Write
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseManagement> CourseManagements { get; set; }
        public DbSet<LaboratoryManagement> LaboratoryManagements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            modelBuilder.ApplyConfiguration(new CourseManagementConfiguration());
            modelBuilder.ApplyConfiguration(new LaboratoryManagementConfiguration());
        }
    }
}
