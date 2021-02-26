using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBooking.DataAccess.MSSQL.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additional_Service_Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additional_Service_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel_Classification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_Classification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel_Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_Image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Person_Info",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    middlename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Info", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Room_Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Room_Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Additional_Service",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    service_type_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additional_Service", x => x.id);
                    table.ForeignKey(
                        name: "FK_Additional_Service_Additional_Service_Type",
                        column: x => x.service_type_id,
                        principalTable: "Additional_Service_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.id);
                    table.ForeignKey(
                        name: "FK_Street_City",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person_Image",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Image", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_Person_Image_Person_Info",
                        column: x => x.person_id,
                        principalTable: "Person_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Person_Info",
                        column: x => x.id,
                        principalTable: "Person_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    floor = table.Column<byte>(type: "tinyint", nullable: false),
                    number = table.Column<short>(type: "smallint", nullable: false),
                    room_type_id = table.Column<int>(type: "int", nullable: false),
                    special_cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.id);
                    table.ForeignKey(
                        name: "FK_Room_Room_Type",
                        column: x => x.room_type_id,
                        principalTable: "Room_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hotel_class_id = table.Column<int>(type: "int", nullable: false),
                    stars = table.Column<byte>(type: "tinyint", nullable: false),
                    street_id = table.Column<int>(type: "int", nullable: false),
                    home_number = table.Column<byte>(type: "tinyint", nullable: false),
                    image_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hotel_Hotel_Classification",
                        column: x => x.hotel_class_id,
                        principalTable: "Hotel_Classification",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotel_Hotel_Image",
                        column: x => x.image_id,
                        principalTable: "Hotel_Image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotel_Street",
                        column: x => x.street_id,
                        principalTable: "Street",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room_Info",
                columns: table => new
                {
                    room_id = table.Column<int>(type: "int", nullable: false),
                    rooms_amount = table.Column<byte>(type: "tinyint", nullable: false),
                    square_meters = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    kitchen = table.Column<bool>(type: "bit", nullable: false),
                    bathroom = table.Column<bool>(type: "bit", nullable: false),
                    conditioner = table.Column<bool>(type: "bit", nullable: false),
                    balcony = table.Column<bool>(type: "bit", nullable: false),
                    tv = table.Column<bool>(type: "bit", nullable: false),
                    washing_machine = table.Column<bool>(type: "bit", nullable: false),
                    sound_isolation = table.Column<bool>(type: "bit", nullable: false),
                    image_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Info", x => x.room_id);
                    table.ForeignKey(
                        name: "FK_Room_Info_Room",
                        column: x => x.room_id,
                        principalTable: "Room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_Info_Room_Image",
                        column: x => x.image_id,
                        principalTable: "Room_Image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    room_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    booking_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_Booking_Booking_Status",
                        column: x => x.booking_status_id,
                        principalTable: "Booking_Status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Hotel",
                        column: x => x.hotel_id,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Room",
                        column: x => x.room_id,
                        principalTable: "Room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Additional_Service",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    additional_service_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "time(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Additional_Service", x => x.id);
                    table.ForeignKey(
                        name: "FK_Booking_Additional_Service_Additional_Service",
                        column: x => x.additional_service_id,
                        principalTable: "Additional_Service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Additional_Service_Booking",
                        column: x => x.booking_id,
                        principalTable: "Booking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Assigned_Person",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Assigned_Person", x => new { x.booking_id, x.person_id });
                    table.ForeignKey(
                        name: "FK_Booking_Assigned_Person_Booking",
                        column: x => x.booking_id,
                        principalTable: "Booking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Assigned_Person_Person_Info",
                        column: x => x.person_id,
                        principalTable: "Person_Info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    payment_type_id = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "date", nullable: false),
                    payment_time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cheque_Booking",
                        column: x => x.booking_id,
                        principalTable: "Booking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cheque_Payment_Type",
                        column: x => x.payment_type_id,
                        principalTable: "Payment_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Service_service_type_id",
                table: "Additional_Service",
                column: "service_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_booking_status_id",
                table: "Booking",
                column: "booking_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_hotel_id",
                table: "Booking",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_room_id",
                table: "Booking",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_user_id",
                table: "Booking",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Additional_Service_additional_service_id",
                table: "Booking_Additional_Service",
                column: "additional_service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Additional_Service_booking_id",
                table: "Booking_Additional_Service",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Assigned_Person_person_id",
                table: "Booking_Assigned_Person",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cheque_booking_id",
                table: "Cheque",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cheque_payment_type_id",
                table: "Cheque",
                column: "payment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_hotel_class_id",
                table: "Hotel",
                column: "hotel_class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_image_id",
                table: "Hotel",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_street_id",
                table: "Hotel",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_room_type_id",
                table: "Room",
                column: "room_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Info_image_id",
                table: "Room_Info",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_Street_city_id",
                table: "Street",
                column: "city_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Additional_Service");

            migrationBuilder.DropTable(
                name: "Booking_Assigned_Person");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "Person_Image");

            migrationBuilder.DropTable(
                name: "Room_Info");

            migrationBuilder.DropTable(
                name: "Additional_Service");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Payment_Type");

            migrationBuilder.DropTable(
                name: "Room_Image");

            migrationBuilder.DropTable(
                name: "Additional_Service_Type");

            migrationBuilder.DropTable(
                name: "Booking_Status");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hotel_Classification");

            migrationBuilder.DropTable(
                name: "Hotel_Image");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Room_Type");

            migrationBuilder.DropTable(
                name: "Person_Info");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
