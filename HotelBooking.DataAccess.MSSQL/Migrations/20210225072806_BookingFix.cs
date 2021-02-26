using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBooking.DataAccess.MSSQL.Migrations
{
    public partial class BookingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Hotel",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_hotel_id",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Booking_hotel_id",
                table: "Booking",
                column: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Hotel",
                table: "Booking",
                column: "hotel_id",
                principalTable: "Hotel",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
