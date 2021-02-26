using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class City
    {
        public City()
        {
            Streets = new HashSet<Street>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}
