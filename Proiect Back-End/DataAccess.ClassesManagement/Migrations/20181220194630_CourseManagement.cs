using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.ClassesManagement.Migrations
{
    public partial class CourseManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratories");

            migrationBuilder.CreateTable(
                name: "CourseManagements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    ClassId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserPosition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseManagements_Courses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryManagements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    ClassId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserPosition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryManagements_Courses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseManagements_ClassId",
                table: "CourseManagements",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryManagements_ClassId",
                table: "LaboratoryManagements",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseManagements");

            migrationBuilder.DropTable(
                name: "LaboratoryManagements");

            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    CourseTitle = table.Column<string>(maxLength: 35, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    EntityId = table.Column<Guid>(nullable: false),
                    LastChangeDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    Semester = table.Column<int>(maxLength: 2, nullable: false),
                    Year = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.Id);
                });
        }
    }
}
