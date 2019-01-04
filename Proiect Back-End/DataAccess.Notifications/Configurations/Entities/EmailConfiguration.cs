namespace DataAccess.Notifications.Configurations.Entities
{
    using global::Entities.Notifications;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmailConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Subject)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Body)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Receiver)
                .IsRequired();
        }
    }
}
