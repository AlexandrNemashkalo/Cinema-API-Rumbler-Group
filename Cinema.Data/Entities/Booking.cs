using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public List<Seat> Seats { get; set; }
        public DateTime DateOfChange { get; set; } = DateTime.Now;
        public User User { get; set; }
        public Guid UserId { get; set; }
        public StatusBooking Status { get; set; }
        public int StatusId { get; set; } = 1;
        //public string Status { get; set; } = "создан"; // создан || удален || оплачен
    }
}
