using Cinema.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cinema.Core.EF
{
    public class CinemaContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<StatusBooking> StatusBookings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            Hall[] halls = new Hall[]
                {
                    new Hall
                    {
                        Id=1,
                        Title="2D",
                        RowMax = 10,
                        ColumnMax = 5
                    },
                    new Hall
                    {
                        Id=2,
                        Title="3D",
                        RowMax = 5,
                        ColumnMax = 5
                    },
                    new Hall
                    {
                        Id=3,
                        Title="IMAX",
                        RowMax = 20,
                        ColumnMax = 10
                    },
                };

            builder.Entity<Hall>().HasData(halls);


            Movie[] movies = new Movie[]
                {
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Title="Avatar",
                        DurationMinutes = 100,

                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Title="Hobbit",
                        DurationMinutes = 200,
                    }
                };

            builder.Entity<Movie>().HasData(movies);


            Session[] sessions = new Session[]
                {
                    new Session
                    {
                        Id = Guid.NewGuid(),
                        Price = 100, 
                        HallId = halls[0].Id,
                        MovieId =movies[0].Id,
                        DateTime = DateTime.Today
                    }
                };


            builder.Entity<Session>().HasData(sessions);

           
            List<Seat> seats = new List<Seat>();
            for(int i = 0; i < halls[0].RowMax; i++)
            {
                for (int j = 0; j < halls[0].ColumnMax; j++)
                {
                    seats.Add(new Seat
                    {
                        Id = Guid.NewGuid(),
                        Row = i+1,
                        Column = j+1,
                        SessionId = sessions[0].Id,
                    });
                   
                }
            }
            builder.Entity<Seat>().HasData(seats);

            List<StatusBooking> statusBookings = new List<StatusBooking>() {
                new StatusBooking
                {
                    Id = 1,
                    Name ="создан"    
                },
                new StatusBooking
                {
                    Id = 2,
                    Name ="оплачен"
                },
                new StatusBooking
                {
                    Id = 3,
                    Name ="удален"
                }
            };
            builder.Entity<StatusBooking>().HasData(statusBookings);


            base.OnModelCreating(builder);


        }

        public CinemaContext(DbContextOptions<CinemaContext> opt) :
            base(opt)
        {
            Database.EnsureCreated();
        }
    }
}
