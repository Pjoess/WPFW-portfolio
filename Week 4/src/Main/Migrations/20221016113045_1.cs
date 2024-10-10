using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GastInfo",
                columns: table => new
                {
                    GastInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    LaaststBezochteURL = table.Column<string>(type: "TEXT", nullable: false),
                    coordinaat_X = table.Column<int>(type: "INTEGER", nullable: false),
                    coordinaat_Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfo", x => x.GastInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    Probleem = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeBereik_Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeBereik_Eind = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gast",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Favorietid = table.Column<int>(type: "INTEGER", nullable: true),
                    GastInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Begeleidtid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gast", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gast_Attracties_Favorietid",
                        column: x => x.Favorietid,
                        principalTable: "Attracties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Gast_Gast_Begeleidtid",
                        column: x => x.Begeleidtid,
                        principalTable: "Gast",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Gast_GastInfo_GastInfoId",
                        column: x => x.GastInfoId,
                        principalTable: "GastInfo",
                        principalColumn: "GastInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gast_Gebruikers_id",
                        column: x => x.id,
                        principalTable: "Gebruikers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medewerker_Gebruikers_id",
                        column: x => x.id,
                        principalTable: "Gebruikers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    gastid = table.Column<int>(type: "INTEGER", nullable: true),
                    DateTimeBereik_Begin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeBereik_Eind = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Attractieid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Attracties_Attractieid",
                        column: x => x.Attractieid,
                        principalTable: "Attracties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gast_gastid",
                        column: x => x.gastid,
                        principalTable: "Gast",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud",
                columns: table => new
                {
                    doetOnderhoudid = table.Column<int>(type: "INTEGER", nullable: false),
                    onderhoudGedaanid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud", x => new { x.doetOnderhoudid, x.onderhoudGedaanid });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Medewerker_onderhoudGedaanid",
                        column: x => x.onderhoudGedaanid,
                        principalTable: "Medewerker",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Onderhoud_doetOnderhoudid",
                        column: x => x.doetOnderhoudid,
                        principalTable: "Onderhoud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud1",
                columns: table => new
                {
                    coordinatieGedaanid = table.Column<int>(type: "INTEGER", nullable: false),
                    doetCoordinatieid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud1", x => new { x.coordinatieGedaanid, x.doetCoordinatieid });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud1_Medewerker_coordinatieGedaanid",
                        column: x => x.coordinatieGedaanid,
                        principalTable: "Medewerker",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud1_Onderhoud_doetCoordinatieid",
                        column: x => x.doetCoordinatieid,
                        principalTable: "Onderhoud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gast_Begeleidtid",
                table: "Gast",
                column: "Begeleidtid");

            migrationBuilder.CreateIndex(
                name: "IX_Gast_Favorietid",
                table: "Gast",
                column: "Favorietid");

            migrationBuilder.CreateIndex(
                name: "IX_Gast_GastInfoId",
                table: "Gast",
                column: "GastInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoud_onderhoudGedaanid",
                table: "MedewerkerOnderhoud",
                column: "onderhoudGedaanid");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoud1_doetCoordinatieid",
                table: "MedewerkerOnderhoud1",
                column: "doetCoordinatieid");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_Attractieid",
                table: "Reserveringen",
                column: "Attractieid");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_gastid",
                table: "Reserveringen",
                column: "gastid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoud");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoud1");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Medewerker");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Gast");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "GastInfo");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
