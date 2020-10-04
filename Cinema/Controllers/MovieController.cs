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
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repo;
        public MovieController(IMovieRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получить список всех фильмов
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
        /// Поличть фильм по Id
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
        /// Добавить новый фильм
        /// </summary>
        /// <param name="mov"></param>
        /// <returns>созданный фильм</returns>
        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie mov)
        {
            try
            {
                return Ok(await _repo.CreateAsync(mov));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Удалить Фильм 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
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
        /// Обновить информацию о фильме
        /// </summary>
        /// <param name="mov"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Movie mov)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(mov));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
