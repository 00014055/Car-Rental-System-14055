using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Data.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_CustomerId",
                table: "cars",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_customer_CustomerId",
                table: "cars",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_customer_CustomerId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropIndex(
                name: "IX_cars_CustomerId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "cars");
        }
    }
}
