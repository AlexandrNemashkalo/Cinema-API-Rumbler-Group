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
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repo;
        public BookingController(IBookingRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Получить все заказы
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
        /// Получить все заказы определенного пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>список заказов</returns>
        [Authorize]
        [HttpGet("userid/{id}")]
        public async Task<IActionResult> GetBookingsByUser(Guid userId)
        {

            try
            {
                return Ok(await _repo.GetBookingsByUserAsync(userId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Получить заказ по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>заказ</returns>
        [Authorize]
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
        /// Создать заказ
        /// </summary>
        /// <param name="seatsId"> В параметры передается список ID Мест </param>
        /// <returns>созданный заказ или null(это значит что что-то пошло не так)</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<Guid> seatsId)
        {
          
            var email = HttpContext.User.Identities.First()?.Name;            
            try
            {
                return Ok(await _repo.CreateAsync(seatsId, email));
               
         
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Отменить заказ
        /// </summary>
        /// <param name="id"> Id заказа</param>
        /// <returns>true или false</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var email = HttpContext.User.Identities.First()?.Name;
            try
            {
                return Ok(await _repo.DeleteAsync(id, email));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Оплатить заказ
        /// </summary>
        /// <param name="id">Id уже оплаченного заказа</param>
        /// <returns>true или false</returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Pay(Guid id)
        {
           
            try
            {
                return Ok(await _repo.PayAsync(id ));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
