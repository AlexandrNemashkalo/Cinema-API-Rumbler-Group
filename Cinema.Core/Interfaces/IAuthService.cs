using Cinema.Core.EF;
using Cinema.Core.Models;
using Cinema.Data.Dto;
using Cinema.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseToken> LoginAsync(string email, string password);
        Task<ResponseToken> RegisterAsync(UserDto item);
    }
}
