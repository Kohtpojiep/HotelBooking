using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class RoomImage
    {
        public RoomImage()
        {
            RoomInfos = new HashSet<RoomInfo>();
        }

        public int Id { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<RoomInfo> RoomInfos { get; set; }
    }
}
