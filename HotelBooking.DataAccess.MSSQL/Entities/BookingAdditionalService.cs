using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class BookingAdditionalService
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int AdditionalServiceId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual AdditionalService AdditionalService { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
