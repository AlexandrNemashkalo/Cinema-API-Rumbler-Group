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
    public class MovieRepository : IMovieRepository
    {
        public readonly CinemaContext _context;

        public MovieRepository(CinemaContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await  _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            return await _context.Movies.FirstOrDefaultAsync(x=> x.Id ==id);
        }

        public async Task<Movie> CreateAsync(Movie mov)
        {
            var result = await _context.Movies.AddAsync(mov);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Movie mov = await _context.Movies.FirstOrDefaultAsync(e => e.Id == id);
            if (mov == null)
                return false;
            _context.Movies.Remove(mov);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Movie mov)
        {
            Movie movie = await _context.Movies.FirstOrDefaultAsync(e => e.Id == mov.Id);
            if (mov == null)
                return false;
            movie.Title = mov.Title;
            movie.DurationMinutes = mov.DurationMinutes;
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
