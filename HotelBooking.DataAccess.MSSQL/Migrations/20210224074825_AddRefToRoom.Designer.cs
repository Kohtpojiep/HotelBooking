﻿// <auto-generated />
using System;
using HotelBooking.DataAccess.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelBooking.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(BookingHotelsContext))]
    [Migration("20210224074825_AddRefToRoom")]
    partial class AddRefToRoom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.AdditionalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("ServiceTypeId")
                        .HasColumnType("int")
                        .HasColumnName("service_type_id");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Additional_Service");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.AdditionalServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Additional_Service_Type");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int")
                        .HasColumnName("booking_status_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("end_time");

                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("hotel_id");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("start_time");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.BookingAdditionalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdditionalServiceId")
                        .HasColumnType("int")
                        .HasColumnName("additional_service_id");

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("booking_id");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("end_time");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalServiceId");

                    b.HasIndex("BookingId");

                    b.ToTable("Booking_Additional_Service");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.BookingAssignedPerson", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("booking_id");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.HasKey("BookingId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Booking_Assigned_Person");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.BookingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Booking_Status");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Cheque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("booking_id");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date")
                        .HasColumnName("payment_date");

                    b.Property<TimeSpan>("PaymentTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("payment_time");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("payment_type_id");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Cheque");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("HomeNumber")
                        .HasColumnType("tinyint")
                        .HasColumnName("home_number");

                    b.Property<int>("HotelClassId")
                        .HasColumnType("int")
                        .HasColumnName("hotel_class_id");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<byte>("Stars")
                        .HasColumnType("tinyint")
                        .HasColumnName("stars");

                    b.Property<int>("StreetId")
                        .HasColumnType("int")
                        .HasColumnName("street_id");

                    b.HasKey("Id");

                    b.HasIndex("HotelClassId");

                    b.HasIndex("ImageId");

                    b.HasIndex("StreetId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.HotelClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Hotel_Classification");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.HotelImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("image")
                        .HasColumnName("image");

                    b.HasKey("Id");

                    b.ToTable("Hotel_Image");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Payment_Type");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.PersonImage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("image")
                        .HasColumnName("image");

                    b.HasKey("PersonId");

                    b.ToTable("Person_Image");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.PersonInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastname");

                    b.Property<string>("Middlename")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("middlename");

                    b.Property<long?>("Phone")
                        .HasColumnType("bigint")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("Person_Info");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Floor")
                        .HasColumnType("tinyint")
                        .HasColumnName("floor");

                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("hotel_id");

                    b.Property<short>("Number")
                        .HasColumnType("smallint")
                        .HasColumnName("number");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    b.Property<int?>("SpecialCost")
                        .HasColumnType("int")
                        .HasColumnName("special_cost");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.RoomImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image")
                        .HasColumnName("image");

                    b.HasKey("Id");

                    b.ToTable("Room_Image");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.RoomInfo", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.Property<bool>("Balcony")
                        .HasColumnType("bit")
                        .HasColumnName("balcony");

                    b.Property<bool>("Bathroom")
                        .HasColumnType("bit")
                        .HasColumnName("bathroom");

                    b.Property<bool>("Conditioner")
                        .HasColumnType("bit")
                        .HasColumnName("conditioner");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    b.Property<bool>("Kitchen")
                        .HasColumnType("bit")
                        .HasColumnName("kitchen");

                    b.Property<byte>("RoomsAmount")
                        .HasColumnType("tinyint")
                        .HasColumnName("rooms_amount");

                    b.Property<bool>("SoundIsolation")
                        .HasColumnType("bit")
                        .HasColumnName("sound_isolation");

                    b.Property<decimal?>("SquareMeters")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("square_meters");

                    b.Property<bool>("Tv")
                        .HasColumnType("bit")
                        .HasColumnName("tv");

                    b.Property<bool>("WashingMachine")
                        .HasColumnType("bit")
                        .HasColumnName("washing_machine");

                    b.HasKey("RoomId");

                    b.HasIndex("ImageId");

                    b.ToTable("Room_Info");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Room_Type");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Street");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.AdditionalService", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.AdditionalServiceType", "ServiceType")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("ServiceTypeId")
                        .HasConstraintName("FK_Additional_Service_Additional_Service_Type");

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Booking", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .HasConstraintName("FK_Booking_Booking_Status")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Hotel", "Hotel")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK_Booking_Hotel")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_Booking_Room")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Booking_User")
                        .IsRequired();

                    b.Navigation("BookingStatus");

                    b.Navigation("Hotel");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.BookingAdditionalService", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.AdditionalService", "AdditionalService")
                        .WithMany("BookingAdditionalServices")
                        .HasForeignKey("AdditionalServiceId")
                        .HasConstraintName("FK_Booking_Additional_Service_Additional_Service")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Booking", "Booking")
                        .WithMany("BookingAdditionalServices")
                        .HasForeignKey("BookingId")
                        .HasConstraintName("FK_Booking_Additional_Service_Booking")
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.BookingAssignedPerson", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Booking", "Booking")
                        .WithMany("BookingAssignedPeople")
                        .HasForeignKey("BookingId")
                        .HasConstraintName("FK_Booking_Assigned_Person_Booking")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.PersonInfo", "Person")
                        .WithMany("BookingAssignedPeople")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK_Booking_Assigned_Person_Person_Info")
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Cheque", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Booking", "Booking")
                        .WithMany("Cheques")
                        .HasForeignKey("BookingId")
                        .HasConstraintName("FK_Cheque_Booking")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.PaymentType", "PaymentType")
                        .WithMany("Cheques")
                        .HasForeignKey("PaymentTypeId")
                        .HasConstraintName("FK_Cheque_Payment_Type")
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Hotel", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.HotelClassification", "HotelClass")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelClassId")
                        .HasConstraintName("FK_Hotel_Hotel_Classification")
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.HotelImage", "Image")
                        .WithMany("Hotels")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_Hotel_Hotel_Image");

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Street", "Street")
                        .WithMany("Hotels")
                        .HasForeignKey("StreetId")
                        .HasConstraintName("FK_Hotel_Street")
                        .IsRequired();

                    b.Navigation("HotelClass");

                    b.Navigation("Image");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.PersonImage", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.PersonInfo", "Person")
                        .WithOne("PersonImage")
                        .HasForeignKey("HotelBooking.DataAccess.MSSQL.Entities.PersonImage", "PersonId")
                        .HasConstraintName("FK_Person_Image_Person_Info")
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Room", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .HasConstraintName("FK_Room_Room_Type")
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.RoomInfo", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.RoomImage", "Image")
                        .WithMany("RoomInfos")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_Room_Info_Room_Image");

                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.Room", "Room")
                        .WithOne("RoomInfo")
                        .HasForeignKey("HotelBooking.DataAccess.MSSQL.Entities.RoomInfo", "RoomId")
                        .HasConstraintName("FK_Room_Info_Room")
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Street", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.City", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Street_City")
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.User", b =>
                {
                    b.HasOne("HotelBooking.DataAccess.MSSQL.Entities.PersonInfo", "IdNavigation")
                        .WithOne("User")
                        .HasForeignKey("HotelBooking.DataAccess.MSSQL.Entities.User", "Id")
                        .HasConstraintName("FK_User_Person_Info")
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.AdditionalService", b =>
                {
                    b.Navigation("BookingAdditionalServices");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.AdditionalServiceType", b =>
                {
                    b.Navigation("AdditionalServices");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Booking", b =>
                {
                    b.Navigation("BookingAdditionalServices");

                    b.Navigation("BookingAssignedPeople");

                    b.Navigation("Cheques");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.City", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Hotel", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.HotelClassification", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.HotelImage", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.PaymentType", b =>
                {
                    b.Navigation("Cheques");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.PersonInfo", b =>
                {
                    b.Navigation("BookingAssignedPeople");

                    b.Navigation("PersonImage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("RoomInfo");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.RoomImage", b =>
                {
                    b.Navigation("RoomInfos");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.Street", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelBooking.DataAccess.MSSQL.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
