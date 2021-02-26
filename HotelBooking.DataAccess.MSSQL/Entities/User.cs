using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual PersonInfo IdNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
