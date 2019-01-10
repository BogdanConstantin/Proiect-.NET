using Entities.Gamification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Gamification.Configurations.Entities
{
    public class AnswerConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            base.Configure(builder);
            
            builder.HasOne(p => p.Session).WithMany().HasForeignKey(p => p.SessionId);

            builder.Property(p => p.Input)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
