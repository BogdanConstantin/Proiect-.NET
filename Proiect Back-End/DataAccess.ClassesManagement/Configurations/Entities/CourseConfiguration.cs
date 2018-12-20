namespace DataAccess.ClassesManagement.Configurations.Entities
{
    using global::Entities.ClassesManagement;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CourseTitle)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(p => p.Semester)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(p => p.Year)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
