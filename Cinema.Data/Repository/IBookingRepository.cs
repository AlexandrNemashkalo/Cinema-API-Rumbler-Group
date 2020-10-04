using Cinema.Data.Dto;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public interface IBookingRepository
    {
        Task<List<BookingDto>> GetAllAsync();
        Task<List<BookingDto>> GetBookingsByUserAsync(Guid id);
        Task<BookingDto> GetByIdAsync(Guid id);
        Task<BookingDto> CreateAsync(List<Guid> seatsId, string email);
        Task<bool> PayAsync(Guid id);
        Task<bool> DeleteAsync(Guid id, string email);

    }
}
