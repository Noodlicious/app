using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApp.Migrations
{
    public partial class DatabaseChange3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "APINoodleId",
                table: "Noodles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APINoodleId",
                table: "Noodles");
        }
    }
}
