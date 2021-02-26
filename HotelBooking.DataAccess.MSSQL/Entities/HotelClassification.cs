using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class HotelClassification
    {
        public HotelClassification()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
