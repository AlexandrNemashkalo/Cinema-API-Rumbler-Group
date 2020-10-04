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
        public MovieForSessionDto Movie { get; set; }
        public HallForSessionDto Hall { get; set; }
        public int ColFreeSeats { get; set; }
        //public List<Seat> Seats { get; set; }
    }

    public class MovieForSessionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
    }
    public class HallForSessionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ColAllSeats { get; set; }
    }


}
