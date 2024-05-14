using Cinema.Core.Domain.DTO.Propositions;
using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cinema.Core.Domain.DTO.User
{
    public class UserResponse
    {

        public ICollection<Entities.Ticket> tickets { get; set; }
        public ICollection<Proposition> propositions { get; set; }
        public UserResponse()
        {
            foreach (var ticket in tickets)
            {
               this.tickets = new List<Entities.Ticket>();
            }

            foreach (var proposition in propositions)
            {
                this.propositions = new List<Proposition>();
            }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public UserAddRequest ToAddRequest()
        {
            return new UserAddRequest(tickets, propositions);
        }
    }

    public static class UserExtensions
    {
        public static UserResponse ToUserResponse(this CinemaUser user)
        {
            return new UserResponse
            {
                tickets = user.Tickets,
                propositions = user.Propositions
            };

            /*   foreach (var ticket in user.tickets)
               {
                   response.tickets.Add(ticket.ToTicket());
               }

               foreach (var prop in user.propositions)
               {
                   response.propositions.Add(prop.ToProposition());
               }*/

            // return response;
        }
    }
}
