using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class AdditionalService
    {
        public AdditionalService()
        {
            BookingAdditionalServices = new HashSet<BookingAdditionalService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int? ServiceTypeId { get; set; }

        public virtual AdditionalServiceType ServiceType { get; set; }
        public virtual ICollection<BookingAdditionalService> BookingAdditionalServices { get; set; }
    }
}
