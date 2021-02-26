using System;
using HotelBooking.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL
{
    public partial class BookingHotelsContext : DbContext
    {

        public BookingHotelsContext(DbContextOptions<BookingHotelsContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }
        public virtual DbSet<AdditionalServiceType> AdditionalServiceTypes { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingAdditionalService> BookingAdditionalServices { get; set; }
        public virtual DbSet<BookingAssignedPerson> BookingAssignedPeople { get; set; }
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; }
        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelClassification> HotelClassifications { get; set; }
        public virtual DbSet<HotelImage> HotelImages { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PersonImage> PersonImages { get; set; }
        public virtual DbSet<PersonInfo> PersonInfos { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomImage> RoomImages { get; set; }
        public virtual DbSet<RoomInfo> RoomInfos { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.ToTable("Additional_Service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(350)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .HasConstraintName("FK_Additional_Service_Additional_Service_Type");
            });

            modelBuilder.Entity<AdditionalServiceType>(entity =>
            {
                entity.ToTable("Additional_Service_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingStatusId).HasColumnName("booking_status_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.EndTime)
                    .HasColumnType("time(6)")
                    .HasColumnName("end_time");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.StartTime)
                    .HasColumnType("time(6)")
                    .HasColumnName("start_time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Booking_Status");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Room");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<BookingAdditionalService>(entity =>
            {
                entity.ToTable("Booking_Additional_Service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalServiceId).HasColumnName("additional_service_id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.EndTime)
                    .HasColumnType("time(6)")
                    .HasColumnName("end_time");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.StartTime)
                    .HasColumnType("time(6)")
                    .HasColumnName("start_time");

                entity.HasOne(d => d.AdditionalService)
                    .WithMany(p => p.BookingAdditionalServices)
                    .HasForeignKey(d => d.AdditionalServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Additional_Service_Additional_Service");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingAdditionalServices)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Additional_Service_Booking");
            });

            modelBuilder.Entity<BookingAssignedPerson>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.PersonId });

                entity.ToTable("Booking_Assigned_Person");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingAssignedPeople)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Assigned_Person_Booking");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BookingAssignedPeople)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Assigned_Person_Person_Info");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.ToTable("Booking_Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.ToTable("Cheque");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentTime)
                    .HasColumnType("time(6)")
                    .HasColumnName("payment_time");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cheque_Booking");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cheque_Payment_Type");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HomeNumber).HasColumnName("home_number");

                entity.Property(e => e.HotelClassId).HasColumnName("hotel_class_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Stars).HasColumnName("stars");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.HotelClass)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.HotelClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotel_Hotel_Classification");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Hotel_Hotel_Image");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotel_Street");
            });

            modelBuilder.Entity<HotelClassification>(entity =>
            {
                entity.ToTable("Hotel_Classification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HotelImage>(entity =>
            {
                entity.ToTable("Hotel_Image");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("image");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("Payment_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PersonImage>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("Person_Image");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("image");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.PersonImage)
                    .HasForeignKey<PersonImage>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Image_Person_Info");
            });

            modelBuilder.Entity<PersonInfo>(entity =>
            {
                entity.ToTable("Person_Info");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(50)
                    .HasColumnName("middlename");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

                entity.Property(e => e.SpecialCost).HasColumnName("special_cost");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Room_Type");
            });

            modelBuilder.Entity<RoomImage>(entity =>
            {
                entity.ToTable("Room_Image");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("image");
            });

            modelBuilder.Entity<RoomInfo>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("Room_Info");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("room_id");

                entity.Property(e => e.Balcony).HasColumnName("balcony");

                entity.Property(e => e.Bathroom).HasColumnName("bathroom");

                entity.Property(e => e.Conditioner).HasColumnName("conditioner");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Kitchen).HasColumnName("kitchen");

                entity.Property(e => e.RoomsAmount).HasColumnName("rooms_amount");

                entity.Property(e => e.SoundIsolation).HasColumnName("sound_isolation");

                entity.Property(e => e.SquareMeters)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("square_meters");

                entity.Property(e => e.Tv).HasColumnName("tv");

                entity.Property(e => e.WashingMachine).HasColumnName("washing_machine");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.RoomInfos)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Room_Info_Room_Image");

                entity.HasOne(d => d.Room)
                    .WithOne(p => p.RoomInfo)
                    .HasForeignKey<RoomInfo>(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Info_Room");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("Room_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("Street");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Street_City");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Person_Info");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
