using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Cinema.Core.Domain.Entities
{
    public class CinemaUser : IdentityUser<Guid>
    {
        public CinemaUser()
        {
            tickets = new HashSet<Ticket> ();
            propositions = new HashSet<Proposition> ();
        }
        public ICollection<Ticket> tickets { get; private set; }        
        public ICollection<Proposition> propositions { get; private set; }
    }
}
