using Cinema.Core.Domain.DTO.Propositions;
using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.User
{
    public class UserUpdate
    {

        public UserUpdate(ICollection<Entities.Ticket> Tickets, ICollection<Proposition> Propositions)
        {
            foreach (var ticket in tickets)
            {
                tickets = Tickets;
            }

            foreach (var prop in propositions)
            {
                propositions = Propositions;
            }
        }
        public ICollection<Entities.Ticket> tickets { get; set; }
        public ICollection<Proposition> propositions { get; set; }

        public ICollection<TicketAddRequest> Tickets { get; set; }
        public ICollection<AddProposition> Propositions { get; set; }


        public CinemaUser ToCinemaUser()
        {
            var user = new CinemaUser()
            {


            };

            foreach (var ticket in Tickets)
            {
                user.tickets.Add(ticket.ToTicket()/*Віталій має зробити ToTicket метод*/);
            }

            foreach (var prop in Propositions)
            {
                user.propositions.Add(prop.ToProposition());
            }

            return user;
        }

    }
}