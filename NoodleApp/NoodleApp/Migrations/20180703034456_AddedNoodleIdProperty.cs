using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApp.Migrations
{
    public partial class AddedNoodleIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Noodles",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "NoodleId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Noodles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Noodles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Noodles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flavor",
                table: "Noodles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Noodles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoodleId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "Flavor",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Noodles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Noodles",
                newName: "ID");
        }
    }
}
