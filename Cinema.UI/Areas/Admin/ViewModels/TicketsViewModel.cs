using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.UI.Areas.Admin.ViewModels
{
    public class TicketsViewModel
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SeanceId { get; set; }
        public Seance? Seance { get; set; }
        public Guid UserId { get; set; }
        public CinemaUser? User { get; set; }

        public TicketAddRequest ToTicketAddRequest()
        {
            return new TicketAddRequest()
            {
                SeatNumber = SeatNumber,
                Price = Price,
                IsAvailable = IsAvailable,
                SeanceId = SeanceId,
                UserId = UserId
            };
        }
        public TicketUpdateRequest ToTicketUpdateRequest() 
        {  
            return new TicketUpdateRequest() 
            {  
                SeatNumber = SeatNumber, 
                Price = Price, 
                IsAvailable = IsAvailable, 
                SeanceId = SeanceId, 
                UserId = UserId 
            }; 
        }
    }
    public static class TicketResponseExtensions
    {
        public static TicketsViewModel ToTicketViewModel(this TicketResponse ticketResponse)
        {
            return new TicketsViewModel()
            {
                Id= ticketResponse.Id,
                SeatNumber= ticketResponse.SeatNumber,
                Price = ticketResponse.Price,
                IsAvailable = ticketResponse.IsAvailable,
                SeanceId = ticketResponse.SeanceId,
                Seance = ticketResponse.Seance,
                UserId= ticketResponse.UserId,
                User = ticketResponse.User
            };
        }
    }
}
