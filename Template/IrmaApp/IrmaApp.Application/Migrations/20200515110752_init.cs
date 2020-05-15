using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IrmaApp.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    SenzorId = table.Column<int>(nullable: false),
                    ImeSenzora = table.Column<string>(nullable: true),
                    TipSenzora = table.Column<string>(nullable: true),
                    VrijemeMjerenja = table.Column<DateTime>(nullable: false),
                    MinVrijednost = table.Column<string>(nullable: true),
                    MaxVrijednost = table.Column<string>(nullable: true),
                    Alarm = table.Column<string>(nullable: true),
                    VrijednostMjerenja = table.Column<double>(nullable: false),
                    ValidnostMjeranja = table.Column<string>(nullable: true),
                    UredjajId = table.Column<int>(nullable: false),
                    UredjajId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senzori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Senzori_Uredjaji_UredjajId1",
                        column: x => x.UredjajId1,
                        principalTable: "Uredjaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Senzori_UredjajId1",
                table: "Senzori",
                column: "UredjajId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Senzori");

            migrationBuilder.DropTable(
                name: "XMLDocs");

            migrationBuilder.DropTable(
                name: "Uredjaji");
        }
    }
}
