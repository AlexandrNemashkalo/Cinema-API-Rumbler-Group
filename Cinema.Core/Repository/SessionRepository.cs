using Cinema.Core.EF;
using Cinema.Data.Converters;
using Cinema.Data.Dto;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Repository
{
    public class SessionRepository : ISessionRepository
    {
        public readonly CinemaContext _context;

        public SessionRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<SessionDto>> GetAllAsync()
        {
            List<Session> sessions = await _context.Sessions.Include(x => x.Movie).Include(x => x.Hall).Include(x => x.Seats).ToListAsync();
            return SessionConverter.Convert(sessions);
        }


        public async Task<SessionDto> GetByIdAsync(Guid id)
        {
            Session session = await _context.Sessions
                .Include(x => x.Movie)
                .Include(x => x.Hall)
                .Include(x => x.Seats)
                .FirstOrDefaultAsync(x => x.Id == id);
            return  SessionConverter.Convert(session);
        }

        public async Task<Session> CreateAsync(Session session)
        {
            session.Hall = await _context.Halls.FirstOrDefaultAsync(x => x.Id == session.HallId);
            session.Movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == session.MovieId);

            var result = await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();

            for (int i = 0; i < result.Entity.Hall.RowMax; i++)
            {
                for (int j = 0; j < result.Entity.Hall.ColumnMax; j++)
                {
                    await _context.Seats.AddAsync(new Seat
                    {
                        Row = i + 1,
                        Column = j + 1,
                        Session = session,
                    });
                }
            }
            await _context.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            Session ses = await _context.Sessions.FirstOrDefaultAsync(e => e.Id == id);
            if (ses == null)
                return false;
            _context.Sessions.Remove(ses);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(Session s)
        {
            Session session = await _context.Sessions.FirstOrDefaultAsync(e => e.Id == s.Id);
            if (session == null)
                return false;
            session.Price = s.Price;
            session.DateTime = s.DateTime;
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
