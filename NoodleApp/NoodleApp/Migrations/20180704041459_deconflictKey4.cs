using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApp.Migrations
{
    public partial class deconflictKey4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Noodles_NoodleId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_NoodleId",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reviews_NoodleId",
                table: "Reviews",
                column: "NoodleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Noodles_NoodleId",
                table: "Reviews",
                column: "NoodleId",
                principalTable: "Noodles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
