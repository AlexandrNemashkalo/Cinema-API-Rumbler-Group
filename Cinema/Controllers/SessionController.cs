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
    public class SessionController : Controller
    {
        private readonly ISessionRepository _repo;
        public SessionController(ISessionRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получить все сеансы
        /// </summary>
        /// <returns></returns>
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
        /// Получить сеанс по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Создать сеанс
        /// </summary>
        /// <param name="ses"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Session ses)
        {
            try
            {
                return Ok(await _repo.CreateAsync(ses));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Удалить сеанс
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
        /// Обновить сеанс
        /// </summary>
        /// <param name="ses"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Session ses)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(ses));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
