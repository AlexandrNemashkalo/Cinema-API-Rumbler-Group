using Cinema.Data.Dto;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Data.Converters
{
    public static class SeatConverter
    {

        public static SeatDto Convert(Seat seat)
        {
            return new SeatDto
            {
                Id = seat.Id,
                Row = seat.Row,
                Column = seat.Column,
                Session = SessionConverter.Convert(seat.Session),
                BookingId = seat.BookingId
            };
        }

        public static Seat Convert(SeatDto seatdto)
        {
            return new Seat
            {
                Id = seatdto.Id,
                Row = seatdto.Row,
                Column = seatdto.Column,
                SessionId = seatdto.Session.Id,
                BookingId = seatdto.BookingId,
                Session = SessionConverter.Convert(seatdto.Session),
            };
        }

        public static List<SeatDto> Convert(List<Seat> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Seat> Convert(List<SeatDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
      
    }
}
