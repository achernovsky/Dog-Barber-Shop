using Microsoft.EntityFrameworkCore.Migrations;

namespace Dog_Barber_Shop_API.Migrations
{
    public partial class ChangePropName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "DogName");

            migrationBuilder.AddColumn<string>(
                name: "DogName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogName",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DogName",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
