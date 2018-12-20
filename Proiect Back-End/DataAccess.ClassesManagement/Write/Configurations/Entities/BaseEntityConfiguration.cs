using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ClassesManagement.Write.Configurations.Entities
{
    public abstract class BaseEntityConfiguration
    {
        public void Configure<T>(EntityTypeBuilder<T> builder)
            where T : BaseEntity
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.EntityId)
                .IsRequired();

            builder.Property(p => p.LastChangeDate)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(p => p.DeletedDate)
                .HasMaxLength(7);
        }
    }
}
