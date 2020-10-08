using Cinema.Data.Dto;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Data.Converters
{
    public static class BookingConverter
    {
        public static BookingDto Convert(Booking booking)
        {

            return new BookingDto
            {
                Id = booking.Id,
                Seats = SeatConverter.Convert(booking.Seats),
                DateOfChange = booking.DateOfChange,
                UserEmail = booking.User?.Email,
                UserId = booking.User.Id,
                UserName = booking.User?.Name,
                StatusId = booking.StatusId,
                StatusName = booking.Status.Name,
                SumMoney = booking.Seats.Sum(x => x.Session.Price),

            };
        }

        public static Booking Convert(BookingDto booking)
        {

            return new Booking
            {
                Id = booking.Id,
                Seats = SeatConverter.Convert(booking.Seats),
                DateOfChange = booking.DateOfChange,
                UserId = booking.UserId,
                StatusId = booking.StatusId,
            };
        }


        public static List<BookingDto> Convert(List<Booking> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Booking> Convert(List<BookingDto> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
    }
}
