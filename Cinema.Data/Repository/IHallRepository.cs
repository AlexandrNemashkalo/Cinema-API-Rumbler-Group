using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public interface IHallRepository
    {
        Task<List<Hall>> GetAllAsync();
        Task<Hall> GetByIdAsync(int id);
        Task<Hall> CreateAsync(Hall hall);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Hall hall);
    }
}
