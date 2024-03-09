using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "cars");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Owner_id",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "Owner_id",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "cars");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
