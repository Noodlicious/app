using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApp.Migrations
{
    public partial class DatabaseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Noodles");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Noodles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Noodles");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Noodles",
                nullable: true);
        }
    }
}
