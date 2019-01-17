using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Gamification.Migrations
{
    public partial class SecurityCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Sessions",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Sessions");
        }
    }
}
