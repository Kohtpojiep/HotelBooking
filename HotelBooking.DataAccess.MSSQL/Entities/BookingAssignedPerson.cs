using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class BookingAssignedPerson
    {
        public int BookingId { get; set; }
        public int PersonId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual PersonInfo Person { get; set; }
    }
}
