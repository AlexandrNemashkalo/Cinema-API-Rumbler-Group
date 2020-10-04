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
    public class HallController : Controller
    {
        private readonly IHallRepository _repo;
        public HallController(IHallRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получить все Помещения
        /// </summary>
        /// <returns>Список залов</returns>
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
        /// Получить помещение по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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
        /// Добавить новое помещение
        /// </summary>
        /// <param name="hall"></param>
        /// <returns></returns>
        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Hall hall)
        {
            try
            {
                return Ok(await _repo.CreateAsync(hall));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Удалить помещение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
        /// Обновить помещение
        /// </summary>
        /// <param name="hall">обьект помещения </param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Hall hall)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(hall));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
