using Cinema.Data.Dto;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public interface ISessionRepository
    {
        Task<List<SessionDto>> GetAllAsync();
        Task<SessionDto> GetByIdAsync(Guid id);
        Task<Session> CreateAsync(Session mov);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(Session mov);
    }
}
