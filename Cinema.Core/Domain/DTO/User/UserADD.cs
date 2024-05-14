using Cinema.Core.Domain.DTO.Propositions;
using Cinema.Core.Domain.DTO;
using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Cinema.Core.Domain.DTO.Ticket;

namespace Cinema.Core.Domain.DTO.User
{
    public class UserADD
    {
        public ICollection<Entities.Ticket> tickets { get; set; }
        public ICollection<Proposition> propositions { get; set; }
        public ICollection<AddProposition> addPropositions { get; set; }
        public ICollection<TicketAddRequest> addTickets { get; set; }

        public UserADD(ICollection<Entities.Ticket> Tickets, ICollection<Proposition> Propositions)
        {
            tickets = Tickets;
            propositions = Propositions;
        }

        public CinemaUser ToCinemaUser()
        {
            var user = new CinemaUser()
            {

            };


            foreach (var ticket in addTickets)
            {
                user.tickets.Add(ticket.ToTicket()/*Віталій має зробити ToTicket метод*/);
            }

            foreach (var prop in addPropositions)
            {
                user.propositions.Add(prop.ToProposition());
            }
            return user;
        }

    }


}






