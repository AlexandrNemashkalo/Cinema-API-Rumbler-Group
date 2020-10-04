using Cinema.Core.Interfaces;
using Cinema.Data.Dto;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.API.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repo.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Найти пользователя по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _repo.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Найти пользователя по его Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                return Ok(await _repo.GetByEmailAsync(email));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _repo.DeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Обновить данные о пользователе
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto us)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(us));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
