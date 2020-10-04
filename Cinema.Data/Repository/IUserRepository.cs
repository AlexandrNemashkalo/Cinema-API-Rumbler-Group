using Cinema.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> GetByEmailAsync(string email);
        Task<bool> UpdateAsync(UserDto user);
        Task<bool> DeleteAsync(Guid id);
    }
}
