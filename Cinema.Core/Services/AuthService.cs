using Cinema.Core.EF;
using Cinema.Core.Interfaces;
using Cinema.Core.Models;
using Cinema.Data.Converters;
using Cinema.Data.Dto;
using Cinema.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Services
{
    public class AuthService : IAuthService
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwt;

        public AuthService(SignInManager<User> sim, UserManager<User> um, IJwtGenerator jwt, CinemaContext context,
            IConfiguration configuration)
        {
            _signInManager = sim;
            _userManager = um;
            _jwt = jwt;
        }

        public async Task<ResponseToken> LoginAsync(string email, string password)
        {
            try
            {
                if (email == null || password == null)
                    return null;
                var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
                if (result.Succeeded)
                {
                    var appUser = await _userManager.FindByEmailAsync(email);
                    return await _jwt.GenerateJwtToken(appUser);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


         public async Task<ResponseToken> RegisterAsync(UserDto item)
         {
             try
             {
                 User user = UserConverter.Convert(item);
                 if (user == null)
                     return null;
                 var result = await _userManager.CreateAsync(user, item.Password);
                 if (result.Succeeded)
                 {
                     await _userManager.AddToRoleAsync(user, "user");
                     await _signInManager.SignInAsync(user, false);
                     return await _jwt.GenerateJwtToken(user);
                 }
                 return null;
             }
             catch (Exception)
             {
                 return null;
             }
         }

    }

    

}
