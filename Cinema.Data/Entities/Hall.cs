using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RowMax { get; set; }
        public int  ColumnMax {get;set;}

        public List<Session> Sessions { get; set; }
    }
}
