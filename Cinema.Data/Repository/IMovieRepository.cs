using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(Guid id);
        Task<Movie> CreateAsync(Movie mov);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(Movie mov);
    }
}
