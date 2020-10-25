using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddWorkingTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorWorkingTime",
                columns: table => new
                {
                    FK_ID_User = table.Column<int>(nullable: false),
                    time_from = table.Column<TimeSpan>(nullable: false),
                    time_to = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorWorkingTime", x => x.FK_ID_User);
                    table.ForeignKey(
                        name: "FK_DoctorWorkingTime_User_FK_ID_User",
                        column: x => x.FK_ID_User,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorWorkingTime");
        }
    }
}
