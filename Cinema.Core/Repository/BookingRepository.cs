using Cinema.Core.EF;
using Cinema.Data.Converters;
using Cinema.Data.Dto;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public readonly CinemaContext _context;
        public readonly UserManager<User> _um;
        public readonly RoleManager<IdentityRole<Guid>> _rm;

        public BookingRepository(CinemaContext context, UserManager<User> um, RoleManager<IdentityRole<Guid>> rm )
        {
            _context = context;
            _um = um;
            _rm = rm;
        }

        

        public async Task<List<BookingDto>> GetAllAsync()
        {
            List<Booking> bookings = await _context.Bookings
                 .Include(x => x.User)
                .Include(x => x.Seats).ThenInclude(y => y.Session).ThenInclude(x => x.Movie)
                .Include(x => x.Seats).ThenInclude(y => y.Session).ThenInclude(x => x.Hall)
                .ToListAsync();

            return BookingConverter.Convert(bookings);
        }

        public async Task<List<BookingDto>> GetBookingsByUserAsync(Guid userId)
        {
            List<Booking> booking = await _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Seats).ThenInclude(y => y.Session).ThenInclude(x => x.Movie)
                .Include(x => x.Seats).ThenInclude(y => y.Session).ThenInclude(x => x.Hall)
                .Where(x => x.UserId == userId).ToListAsync();
            if (booking == null)
                return null;
            return BookingConverter.Convert(booking);
        }


        public async Task<BookingDto> GetByIdAsync(Guid id)
        {
            Booking booking = await _context.Bookings
                .Include(x => x.User)
                .Include(x => x.Seats).ThenInclude(y => y.Session).ThenInclude(x => x.Movie)
                .Include(x =>x.Seats).ThenInclude(y => y.Session).ThenInclude(x => x.Hall)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (booking == null)
                return null;
            return BookingConverter.Convert(booking);
        }


        public async Task<BookingDto> CreateAsync(List<Guid> seatsId, string email)
        {

            User user = await _um.FindByNameAsync(email);
            if (user != null)
            {
                Booking booking = new Booking
                {
                    Status = "создан",
                    User = user,
                    DateOfChange = DateTime.Now
                };
                var result = await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();

                foreach (var seatId in seatsId)
                {
                    var S = await _context.Seats.FirstOrDefaultAsync(x => x.Id == seatId);
                    if (S == null || S.BookingId != null)
                    {
                        _context.Bookings.Remove(result.Entity);
                        await _context.SaveChangesAsync();
                        return null;
                    }
                    S.Booking = booking;
                    S.BookingId = result.Entity.Id;
                    _context.Seats.Update(S);
                }
                await _context.SaveChangesAsync();

                return await GetByIdAsync(result.Entity.Id);
            }
            else
                return null;
        }
       
        


        public async Task<bool> DeleteAsync(Guid id, string email)
        {
            User user = await _um.FindByNameAsync(email);
            Booking booking = await _context.Bookings.Include(x => x.Seats).FirstOrDefaultAsync(e => e.Id == id);
            if((booking.UserId == user.Id && booking!=null) || await  _um.IsInRoleAsync(user, "Admin"))
            {
                foreach (var seat in booking.Seats)
                {
                    seat.Booking = null;
                    seat.BookingId = null;
                    _context.Seats.Update(seat);
                }

                booking.Status = "удален";
                booking.DateOfChange = DateTime.Now;
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            } 
        }

        public async Task<bool> PayAsync(Guid id)
        {
            Booking booking = await _context.Bookings.FirstOrDefaultAsync(e => e.Id == id);
            if (booking != null)
            {
                booking.Status = "оплачен";
                booking.DateOfChange = DateTime.Now;
                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
