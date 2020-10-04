using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public DateTime DateTime {get;set;}
        public Hall Hall { get; set; }
        public int HallId { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
