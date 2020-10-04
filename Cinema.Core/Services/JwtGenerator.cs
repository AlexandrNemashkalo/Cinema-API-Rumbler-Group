using Cinema.Core.EF;
using Cinema.Core.Interfaces;
using Cinema.Core.Models;
using Cinema.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Services
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public JwtGenerator(UserManager<User> um, IConfiguration conf)
        {
            _userManager = um;
            _configuration = conf;
        }


        public async Task<ResponseToken> GenerateJwtToken(User user)
        {   
            try
            {
                var roles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

                claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Issuer"],
                    _configuration["Audience"],
                    claimsIdentity.Claims,
                    signingCredentials: creds
                );

                string jwtToken =  new JwtSecurityTokenHandler().WriteToken(token);
                if (jwtToken == null)
                    return new ResponseToken(500, "Failed to create access token");
                return new ResponseToken(jwtToken);
            }   
            catch (Exception)
            {
                return new ResponseToken(520, "Unknown error");
            }
        }  
    }
}
