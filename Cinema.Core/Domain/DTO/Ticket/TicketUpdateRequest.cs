using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Ticket
{
    public class TicketUpdateRequest
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SeanceId { get; set; }
        //public Seance? Seance { get; set; }
        public Guid UserId { get; set; }
        //public CinemaUser? User { get; set; }
        public Entities.Ticket ToTicket()
        {
            return new Entities.Ticket()
            {
                Id = this.Id,
                SeatNumber = this.SeatNumber,
                Price = this.Price,
                IsAvailable = this.IsAvailable,
                SeanceId = this.SeanceId,
                UserId = this.UserId
            };
        }
    }
}
