using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace Cinema.Data.Entities
{
    public class Seat
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Guid SessionId { get; set; }
        public Guid? BookingId { get; set; }
        public Session Session { get; set; }
        public Booking Booking { get; set; }
    }
}
