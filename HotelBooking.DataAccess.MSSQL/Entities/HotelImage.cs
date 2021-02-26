using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class HotelImage
    {
        public HotelImage()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
