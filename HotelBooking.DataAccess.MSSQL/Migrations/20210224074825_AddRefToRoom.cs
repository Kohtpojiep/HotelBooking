using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBooking.DataAccess.MSSQL.Migrations
{
    public partial class AddRefToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Room_hotel_id",
                table: "Room",
                column: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotel_hotel_id",
                table: "Room",
                column: "hotel_id",
                principalTable: "Hotel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotel_hotel_id",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_hotel_id",
                table: "Room");
        }
    }
}
