using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class nameerrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fisr_name",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "fisr_name",
                table: "User",
                type: "text",
                nullable: true);
        }
    }
}
