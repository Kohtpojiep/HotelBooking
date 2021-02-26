using System;
using System.Collections.Generic;

#nullable disable

namespace HotelBooking.DataAccess.MSSQL.Entities
{
    public partial class PersonInfo
    {
        public PersonInfo()
        {
            BookingAssignedPeople = new HashSet<BookingAssignedPerson>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }

        public virtual PersonImage PersonImage { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BookingAssignedPerson> BookingAssignedPeople { get; set; }
    }
}
