using Entities.Gamification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Gamification.Configurations.Entities
{
    public class SessionConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Question)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.StartDate)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(p => p.EndDate)
                .IsRequired()
                .HasMaxLength(7);
        }
    }
}
