using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Notifications.Configurations.Entities
{
    using global::Entities.Notifications;

    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class BaseEntityConfiguration
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
