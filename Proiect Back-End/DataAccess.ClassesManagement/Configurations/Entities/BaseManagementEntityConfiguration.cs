namespace DataAccess.ClassesManagement.Configurations.Entities
{
    using System;

    using global::Entities.ClassesManagement;

    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class BaseManagementEntityConfiguration : BaseEntityConfiguration
    {
        public new void Configure<T>(EntityTypeBuilder<T> builder) 
            where T : BaseManagementEntity
        {
            base.Configure(builder);

            builder.Property(r => r.UserPosition)
                .IsRequired()
                .HasConversion(
                    s => s.ToString(),
                    s => (UserPosition)Enum.Parse(typeof(UserPosition), s));

            builder.Property(r => r.UserId)
                .IsRequired();
        }
    }
}
