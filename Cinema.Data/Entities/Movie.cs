using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public List<Session> Sessions { get; set; }
        
    }
}
