using Cinema.Core.Models;
using Cinema.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Interfaces
{
    public interface IJwtGenerator
    {
        Task<ResponseToken> GenerateJwtToken(User user);
    }
}
