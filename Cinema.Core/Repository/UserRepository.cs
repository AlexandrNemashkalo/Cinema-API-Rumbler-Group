using Cinema.Core.EF;
using Cinema.Data.Converters;
using Cinema.Data.Dto;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _um;
        private readonly CinemaContext _context;

        public UserRepository(UserManager<User> um, CinemaContext context)
        {
            _context = context;
            _um = um;
        }


        async public Task<List<UserDto>> GetAllAsync()
        {
            return UserConverter.Convert(await _um.Users.ToListAsync());
        }

        async public Task<UserDto> GetByIdAsync(Guid id)
        {
            var result = await _um.FindByIdAsync(id.ToString());
            return UserConverter.Convert(result);
        }

        async public Task<UserDto> GetByEmailAsync(string email)
        {
            return UserConverter.Convert(await _um.FindByEmailAsync(email));
        }

        

        public async Task<bool> UpdateAsync(UserDto user)
        {
            return (await _um.UpdateAsync(UserConverter.Convert(user))).Succeeded;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return (await _um.DeleteAsync(await _um.FindByIdAsync(id.ToString()))).Succeeded;
        }


    }
}
