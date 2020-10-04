using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Data.Entities
{
    public class User : IdentityUser<Guid>
    { 
          public string Name { get; set; }

          public List<Booking> Bookings { get; set; }
    }
}
