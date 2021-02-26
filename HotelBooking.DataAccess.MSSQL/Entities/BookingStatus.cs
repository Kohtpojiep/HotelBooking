﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class BookingStatus
    {
        public BookingStatus()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
