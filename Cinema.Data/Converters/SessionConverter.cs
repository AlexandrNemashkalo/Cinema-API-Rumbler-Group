using Cinema.Data.Dto;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Data.Converters
{
    public static class SessionConverter
    {
        public static SessionDto Convert(Session ses)
        {
            
            return new SessionDto
            {
                Id = ses.Id,
                Price =  ses.Price,
                DateTime = ses.DateTime, 

                MovieId = ses.Movie.Id,
                MovieTitle = ses.Movie.Title,
                DurationMinutes = ses.Movie.DurationMinutes,

                HallId = ses.Hall.Id,
                HallTitle = ses.Hall.Title,
                ColAllSeats = ses.Hall.RowMax * ses.Hall.ColumnMax,
                
                ColFreeSeats = ses.Seats.Where(x => x.BookingId == null).Count()

            };
        }

        public static Session Convert(SessionDto ses)
        {

            return new Session
            {
                Id = ses.Id,
                Price = ses.Price,
                DateTime = ses.DateTime,
                MovieId = ses.MovieId,
                HallId = ses.HallId,
            };
        }

        public static List<SessionDto> Convert(List<Session> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Session> Convert(List<SessionDto> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        /* private static int GetPriceByDate(DateTime datetime)
         {
             if (datetime.ToShortTimeString() == "10:00")
             {
                 return 100;
             }
             else if (datetime.ToShortTimeString() == "19:00")
             {
                 return 200;
             }
             else
                 return -1;
         }*/



    }
}
