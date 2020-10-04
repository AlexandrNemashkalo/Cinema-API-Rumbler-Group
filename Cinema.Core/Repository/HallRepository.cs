using Cinema.Core.EF;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Repository
{
    public class HallRepository : IHallRepository
    {
        public readonly CinemaContext _context;

        public HallRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<Hall>> GetAllAsync()
        {
            return await _context.Halls.ToListAsync();
        }

        public async Task<Hall> GetByIdAsync(int id)
        {
            return await _context.Halls.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Hall> CreateAsync(Hall hall)
        {
            var result = await _context.Halls.AddAsync(hall);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Hall hall = await _context.Halls.FirstOrDefaultAsync(e => e.Id == id);
            if (hall == null)
                return false;
            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Hall h)
        {
            Hall hall = await _context.Halls.FirstOrDefaultAsync(e => e.Id == h.Id);
            if (hall == null)
                return false;
            hall.Title = h.Title;
            hall.RowMax = h.RowMax;
            hall.ColumnMax = h.ColumnMax;
            _context.Halls.Update(hall);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
