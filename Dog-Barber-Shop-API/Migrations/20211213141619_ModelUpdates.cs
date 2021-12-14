using Microsoft.EntityFrameworkCore.Migrations;

namespace Dog_Barber_Shop_API.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogName",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DogName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DogName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
