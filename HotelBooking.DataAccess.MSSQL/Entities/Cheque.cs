using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class Cheque
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public TimeSpan PaymentTime { get; set; }
        public int Price { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
