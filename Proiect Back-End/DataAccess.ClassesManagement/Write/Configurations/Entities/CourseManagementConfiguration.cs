using System;
using System.Collections.Generic;
using System.Text;

using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ClassesManagement.Write.Configurations.Entities
{
    class CourseManagementConfiguration : BaseManagementEntityConfiguration, IEntityTypeConfiguration<CourseManagement>
    {
        public void Configure(EntityTypeBuilder<CourseManagement> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.ManagedCourse).WithMany().HasForeignKey(p => p.ClassId);
        }
    }
}
