using System;
using System.Collections.Generic;
using System.Text;
using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ClassesManagement.Write.Configurations.Entities
{
    class LaboratoryManagementConfiguration : BaseManagementEntityConfiguration, IEntityTypeConfiguration<LaboratoryManagement>
    {
        public void Configure(EntityTypeBuilder<LaboratoryManagement> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.ManagedLaboratory).WithMany().HasForeignKey(p => p.ClassId);
        }
    }
}
