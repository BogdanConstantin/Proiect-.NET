﻿// <auto-generated />
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.ClassesManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181220194630_CourseManagement")]
    partial class CourseManagement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.ClassesManagement.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<DateTime?>("DeletedDate")
                        .HasMaxLength(7);

                    b.Property<Guid>("EntityId");

                    b.Property<DateTime>("LastChangeDate")
                        .HasMaxLength(7);

                    b.Property<int>("Semester")
                        .HasMaxLength(2);

                    b.Property<int>("Year")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Entities.ClassesManagement.CourseManagement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<Guid>("ClassId");

                    b.Property<DateTime?>("DeletedDate")
                        .HasMaxLength(7);

                    b.Property<Guid>("EntityId");

                    b.Property<DateTime>("LastChangeDate")
                        .HasMaxLength(7);

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserPosition")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("CourseManagements");
                });

            modelBuilder.Entity("Entities.ClassesManagement.LaboratoryManagement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<Guid>("ClassId");

                    b.Property<DateTime?>("DeletedDate")
                        .HasMaxLength(7);

                    b.Property<Guid>("EntityId");

                    b.Property<DateTime>("LastChangeDate")
                        .HasMaxLength(7);

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserPosition")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("LaboratoryManagements");
                });

            modelBuilder.Entity("Entities.ClassesManagement.CourseManagement", b =>
                {
                    b.HasOne("Entities.ClassesManagement.Course", "ManagedCourse")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ClassesManagement.LaboratoryManagement", b =>
                {
                    b.HasOne("Entities.ClassesManagement.Course", "ManagedLaboratory")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
