using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gast_GastInfo_GastInfoId",
                table: "Gast");

            migrationBuilder.DropIndex(
                name: "IX_Gast_GastInfoId",
                table: "Gast");

            migrationBuilder.AddColumn<int>(
                name: "ForeignKey",
                table: "GastInfo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GastInfo_ForeignKey",
                table: "GastInfo",
                column: "ForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GastInfo_Gast_ForeignKey",
                table: "GastInfo",
                column: "ForeignKey",
                principalTable: "Gast",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GastInfo_Gast_ForeignKey",
                table: "GastInfo");

            migrationBuilder.DropIndex(
                name: "IX_GastInfo_ForeignKey",
                table: "GastInfo");

            migrationBuilder.DropColumn(
                name: "ForeignKey",
                table: "GastInfo");

            migrationBuilder.CreateIndex(
                name: "IX_Gast_GastInfoId",
                table: "Gast",
                column: "GastInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gast_GastInfo_GastInfoId",
                table: "Gast",
                column: "GastInfoId",
                principalTable: "GastInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
