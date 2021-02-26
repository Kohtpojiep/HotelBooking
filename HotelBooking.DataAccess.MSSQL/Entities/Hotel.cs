using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelClassId { get; set; }
        public byte Stars { get; set; }
        public int StreetId { get; set; }
        public byte HomeNumber { get; set; }
        public int? ImageId { get; set; }

        public virtual HotelClassification HotelClass { get; set; }
        public virtual HotelImage Image { get; set; }
        public virtual Street Street { get; set; }
    }
}
