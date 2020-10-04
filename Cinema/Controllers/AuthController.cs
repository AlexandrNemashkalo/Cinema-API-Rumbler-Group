using Cinema.API.ViewModels;
using Cinema.Core.Interfaces;
using Cinema.Core.Models;
using Cinema.Data.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.API.Controllers
{

    [ApiController]
    [Route("api/[action]")]
    public class AuthController :Controller
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        /// <summary>
        /// Аунтефикация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns>токен или ошибку</returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]  LoginViewModel model)
        {
            try
            {
                return Ok(await _auth.LoginAsync(model.Email, model.Password));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        /// <summary>
        /// Регистрация 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>токен или ошибка</returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]  RegisterViewModel model)
        {
            try
            {
                UserDto userDto = new UserDto
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };
                return Ok(await _auth.RegisterAsync(userDto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        
    }
}
