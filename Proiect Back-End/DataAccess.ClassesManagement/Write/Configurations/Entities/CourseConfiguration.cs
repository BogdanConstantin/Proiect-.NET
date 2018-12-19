﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.ClassesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ClassesManagement.Write.Configurations.Entities
{
    public class CourseConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CourseTitle)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(p => p.Semester)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(p => p.Year)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
