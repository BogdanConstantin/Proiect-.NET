namespace DataAccess.ClassesManagement
{
    using Entities.ClassesManagement;

    using Microsoft.EntityFrameworkCore;
    
    using DataAccess.ClassesManagement.Configurations.Entities;

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
            modelBuilder.ApplyConfiguration(new CourseManagementConfiguration());

            modelBuilder.ApplyConfiguration(new CourseManagementConfiguration());
            modelBuilder.ApplyConfiguration(new LaboratoryManagementConfiguration());
        }
    }
}
