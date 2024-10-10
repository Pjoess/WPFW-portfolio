using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GastInfoId",
                table: "GastInfo",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Attractieid",
                table: "Onderhoud",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "GastInfo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_Attractieid",
                table: "Onderhoud",
                column: "Attractieid");

            migrationBuilder.AddForeignKey(
                name: "FK_Onderhoud_Attracties_Attractieid",
                table: "Onderhoud",
                column: "Attractieid",
                principalTable: "Attracties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onderhoud_Attracties_Attractieid",
                table: "Onderhoud");

            migrationBuilder.DropIndex(
                name: "IX_Onderhoud_Attractieid",
                table: "Onderhoud");

            migrationBuilder.DropColumn(
                name: "Attractieid",
                table: "Onderhoud");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "GastInfo",
                newName: "GastInfoId");

            migrationBuilder.AlterColumn<int>(
                name: "GastInfoId",
                table: "GastInfo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
