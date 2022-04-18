using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoveod_MVC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autoveod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tellija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alguspunkt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lõpppunkt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KohalejoudmiseAeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuhtEesnimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuhtPerenimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valmis = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoveod", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autoveod");
        }
    }
}
