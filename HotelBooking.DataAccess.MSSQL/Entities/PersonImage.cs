using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class PersonImage
    {
        public int PersonId { get; set; }
        public byte[] Image { get; set; }

        public virtual PersonInfo Person { get; set; }
    }
}
