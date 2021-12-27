using Microsoft.EntityFrameworkCore.Migrations;

namespace Dog_Barber_Shop_API.Migrations
{
    public partial class AddDogToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DogId",
                table: "Appointments",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Dogs_DogId",
                table: "Appointments",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Dogs_DogId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DogId",
                table: "Appointments");
        }
    }
}
