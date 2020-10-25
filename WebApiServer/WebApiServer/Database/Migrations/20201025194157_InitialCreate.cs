using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fisr_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    password_hash = table.Column<string>(nullable: true),
                    last_logged = table.Column<DateTime>(nullable: false),
                    account_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecializations",
                columns: table => new
                {
                    FK_ID_User = table.Column<int>(nullable: false),
                    specialization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecializations", x => x.FK_ID_User);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_User_FK_ID_User",
                        column: x => x.FK_ID_User,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    ID_request = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datetime_created = table.Column<DateTime>(nullable: false),
                    datetime_appointment = table.Column<DateTime>(nullable: false),
                    FK_ID_doctor = table.Column<int>(nullable: false),
                    FK_ID_patient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.ID_request);
                    table.ForeignKey(
                        name: "FK_Requests_User_FK_ID_doctor",
                        column: x => x.FK_ID_doctor,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_User_FK_ID_patient",
                        column: x => x.FK_ID_patient,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FK_ID_doctor",
                table: "Requests",
                column: "FK_ID_doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FK_ID_patient",
                table: "Requests",
                column: "FK_ID_patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecializations");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
