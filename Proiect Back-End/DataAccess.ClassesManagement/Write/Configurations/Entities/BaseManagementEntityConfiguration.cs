using System;
using System.Collections.Generic;
using System.Text;
using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ClassesManagement.Write.Configurations.Entities
{
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
