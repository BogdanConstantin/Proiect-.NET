using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.FilesHandler.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(maxLength: 7, nullable: false),
                    DeletedDate = table.Column<DateTime>(maxLength: 7, nullable: true),
                    CourseId = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
