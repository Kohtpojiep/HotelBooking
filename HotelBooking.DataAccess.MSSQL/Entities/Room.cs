using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public byte Floor { get; set; }
        public short Number { get; set; }
        public int RoomTypeId { get; set; }
        public int? SpecialCost { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual RoomInfo RoomInfo { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
