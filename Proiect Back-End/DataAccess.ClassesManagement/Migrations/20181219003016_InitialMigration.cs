using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.ClassesManagement.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    CourseTitle = table.Column<string>(maxLength: 35, nullable: false),
                    Year = table.Column<int>(maxLength: 2, nullable: false),
                    Semester = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    CourseTitle = table.Column<string>(maxLength: 35, nullable: false),
                    Year = table.Column<int>(maxLength: 2, nullable: false),
                    Semester = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Laboratories");
        }
    }
}
