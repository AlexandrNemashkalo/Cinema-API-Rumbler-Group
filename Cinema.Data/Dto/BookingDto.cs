using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Dto
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public List<SeatDto> Seats { get; set; }
        public DateTime DateOfChange { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; } = "создан"; // создан || удален || оплачен
        public int SumMoney { get; set; }
    }

}
