using Entities.Gamification;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Gamification.Configurations.Entities
{
    public class BaseEntityConfiguration
    {
        public void Configure<T>(EntityTypeBuilder<T> builder)
            where T : BaseEntity
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();
        }
    }
}
