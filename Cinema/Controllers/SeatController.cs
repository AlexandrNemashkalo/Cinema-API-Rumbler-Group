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
    public class SeatController : Controller
    {
        private readonly ISeatRepository _repo;
        public SeatController(ISeatRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получить список всех мест для определенного сеанса
        /// </summary>
        /// <param name="sessionId">id сеанса</param>
        /// <returns>список мест</returns>
        [HttpGet("{sessionId}")]
        public async Task<IActionResult> GeSeatsBySession(Guid sessionId)
        {
            try
            {
                return Ok(await _repo.GetSeatsBySessionAsync(sessionId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}
