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
        public DbSet<Laboratory> Laboratories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new LaboratoryConfiguration());
        }
    }
}
