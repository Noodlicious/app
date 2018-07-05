using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApp.Migrations
{
    public partial class AddedLikesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Noodles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Noodles");
        }
    }
}
