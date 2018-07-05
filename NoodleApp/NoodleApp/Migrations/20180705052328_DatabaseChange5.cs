using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApp.Migrations
{
    public partial class DatabaseChange5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Noodles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Noodles",
                nullable: true);
        }
    }
}
