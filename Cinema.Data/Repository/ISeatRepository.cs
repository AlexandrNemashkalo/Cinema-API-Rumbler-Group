using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetSeatsBySessionAsync(Guid sessionid);
    }
}
