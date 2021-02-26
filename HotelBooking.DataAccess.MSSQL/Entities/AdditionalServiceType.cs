using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class AdditionalServiceType
    {
        public AdditionalServiceType()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
