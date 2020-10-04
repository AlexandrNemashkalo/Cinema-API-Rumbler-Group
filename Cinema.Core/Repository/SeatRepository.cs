using Cinema.Core.EF;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Repository
{
    public class SeatRepository: ISeatRepository
    {
        public readonly CinemaContext _context;

        public SeatRepository(CinemaContext context)
        {
            _context = context;
        }

       
        public async Task<List<Seat>> GetSeatsBySessionAsync(Guid sessionId)
        {
            return await _context.Seats
                .Where(x => x.SessionId ==sessionId)
                .OrderBy(x => x.Row).ThenBy(x => x.Column)
                .ToListAsync();
        }
    }
}
