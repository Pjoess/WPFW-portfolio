using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Attracties_Favorietid",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_GastInfo_GastInfoId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Gebruikers_Begeleidtid",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_MedewerkerOnderhoud_Gebruikers_onderhoudGedaanid",
                table: "MedewerkerOnderhoud");

            migrationBuilder.DropForeignKey(
                name: "FK_MedewerkerOnderhoud1_Gebruikers_coordinatieGedaanid",
                table: "MedewerkerOnderhoud1");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveringen_Gebruikers_gastid",
                table: "Reserveringen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_Begeleidtid",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_Favorietid",
                table: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Gebruikers_GastInfoId",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Begeleidtid",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "EersteBezoek",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Favorietid",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "GastInfoId",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "GeboorteDatum",
                table: "Gebruikers");

            migrationBuilder.RenameTable(
                name: "Gebruikers",
                newName: "Gebruiker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker",
                column: "id");

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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gast_Gebruiker_id",
                        column: x => x.id,
                        principalTable: "Gebruiker",
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
                        name: "FK_Medewerker_Gebruiker_id",
                        column: x => x.id,
                        principalTable: "Gebruiker",
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

            migrationBuilder.AddForeignKey(
                name: "FK_MedewerkerOnderhoud_Medewerker_onderhoudGedaanid",
                table: "MedewerkerOnderhoud",
                column: "onderhoudGedaanid",
                principalTable: "Medewerker",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedewerkerOnderhoud1_Medewerker_coordinatieGedaanid",
                table: "MedewerkerOnderhoud1",
                column: "coordinatieGedaanid",
                principalTable: "Medewerker",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveringen_Gast_gastid",
                table: "Reserveringen",
                column: "gastid",
                principalTable: "Gast",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedewerkerOnderhoud_Medewerker_onderhoudGedaanid",
                table: "MedewerkerOnderhoud");

            migrationBuilder.DropForeignKey(
                name: "FK_MedewerkerOnderhoud1_Medewerker_coordinatieGedaanid",
                table: "MedewerkerOnderhoud1");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserveringen_Gast_gastid",
                table: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Gast");

            migrationBuilder.DropTable(
                name: "Medewerker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruiker",
                table: "Gebruiker");

            migrationBuilder.RenameTable(
                name: "Gebruiker",
                newName: "Gebruikers");

            migrationBuilder.AddColumn<int>(
                name: "Begeleidtid",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Gebruikers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EersteBezoek",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Favorietid",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GastInfoId",
                table: "Gebruikers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GeboorteDatum",
                table: "Gebruikers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_Begeleidtid",
                table: "Gebruikers",
                column: "Begeleidtid");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_Favorietid",
                table: "Gebruikers",
                column: "Favorietid");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_GastInfoId",
                table: "Gebruikers",
                column: "GastInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Attracties_Favorietid",
                table: "Gebruikers",
                column: "Favorietid",
                principalTable: "Attracties",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_GastInfo_GastInfoId",
                table: "Gebruikers",
                column: "GastInfoId",
                principalTable: "GastInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Gebruikers_Begeleidtid",
                table: "Gebruikers",
                column: "Begeleidtid",
                principalTable: "Gebruikers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedewerkerOnderhoud_Gebruikers_onderhoudGedaanid",
                table: "MedewerkerOnderhoud",
                column: "onderhoudGedaanid",
                principalTable: "Gebruikers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedewerkerOnderhoud1_Gebruikers_coordinatieGedaanid",
                table: "MedewerkerOnderhoud1",
                column: "coordinatieGedaanid",
                principalTable: "Gebruikers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserveringen_Gebruikers_gastid",
                table: "Reserveringen",
                column: "gastid",
                principalTable: "Gebruikers",
                principalColumn: "id");
        }
    }
}
