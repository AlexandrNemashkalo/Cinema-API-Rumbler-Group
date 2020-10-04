using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Dto
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public SessionDto Session { get; set; }
       // public Guid SessionId { get; set; }
        public Guid? BookingId { get; set; }

       
    }
}
