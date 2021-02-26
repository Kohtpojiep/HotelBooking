using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Cheques = new HashSet<Cheque>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
