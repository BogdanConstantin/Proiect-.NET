using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ClassesManagement.Write.Configurations.Entities
{
    public class LaboratoryConfiguration: BaseEntityConfiguration, IEntityTypeConfiguration<Laboratory>
    {
        public void Configure(EntityTypeBuilder<Laboratory> builder)
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
