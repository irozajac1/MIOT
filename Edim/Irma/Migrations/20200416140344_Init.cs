using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Irma.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XMLDocs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemeOcitanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XMLDocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senzori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenzorId = table.Column<int>(nullable: false),
                    ImeSenzora = table.Column<string>(nullable: true),
                    TipSenzora = table.Column<string>(nullable: true),
                    UredjajId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senzori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Senzori_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mjerenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemeMjerenja = table.Column<string>(nullable: true),
                    MinVrijednost = table.Column<string>(nullable: true),
                    MaxVrijednost = table.Column<string>(nullable: true),
                    Alarm = table.Column<string>(nullable: true),
                    VrijednostMjerenja = table.Column<string>(nullable: true),
                    ValidnostMjeranja = table.Column<string>(nullable: true),
                    SenzorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mjerenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mjerenja_Senzori_SenzorId",
                        column: x => x.SenzorId,
                        principalTable: "Senzori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mjerenja_SenzorId",
                table: "Mjerenja",
                column: "SenzorId");

            migrationBuilder.CreateIndex(
                name: "IX_Senzori_UredjajId",
                table: "Senzori",
                column: "UredjajId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mjerenja");

            migrationBuilder.DropTable(
                name: "XMLDocs");

            migrationBuilder.DropTable(
                name: "Senzori");

            migrationBuilder.DropTable(
                name: "Uredjaji");
        }
    }
}
