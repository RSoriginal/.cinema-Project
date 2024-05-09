using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.Entities
{
    public class CinemaRole : IdentityRole<Guid>
    {
        public CinemaRole(string name) { this.Name = name; }
    }
}
