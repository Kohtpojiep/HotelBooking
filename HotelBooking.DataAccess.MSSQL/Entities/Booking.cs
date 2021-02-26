using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            BookingAdditionalServices = new HashSet<BookingAdditionalService>();
            BookingAssignedPeople = new HashSet<BookingAssignedPerson>();
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BookingStatusId { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BookingAdditionalService> BookingAdditionalServices { get; set; }
        public virtual ICollection<BookingAssignedPerson> BookingAssignedPeople { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
