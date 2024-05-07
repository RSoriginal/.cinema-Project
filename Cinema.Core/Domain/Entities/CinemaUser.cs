using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Cinema.Core.Domain.Entities
{
    public class CinemaUser : IdentityUser<Guid>
    {
        public CinemaUser()
        {
            Tickets = new HashSet<Ticket> ();
            Propositions = new HashSet<Proposition> ();
        }
        public ICollection<Ticket> Tickets { get; private set; }        
        public ICollection<Proposition> Propositions { get; private set; }
    }
}
