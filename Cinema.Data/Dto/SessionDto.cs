using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Dto
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
        
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int DurationMinutes { get; set; }

        public int HallId { get; set; }
        public string HallTitle { get; set; }
        public int ColAllSeats { get; set; }

        public int ColFreeSeats { get; set; }
        //public List<Seat> Seats { get; set; }
    }




}
