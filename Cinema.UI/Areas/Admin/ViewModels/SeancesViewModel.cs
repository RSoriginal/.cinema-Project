using Cinema.Core.Domain.DTO.Seance;
using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.UI.Areas.Admin.ViewModels
{
    public class SeancesViewModel
    {
        public int Id { get; set; }
        public int MaxTickets { get; set; }
        public DateTime AssignedAt { get; set; }
        public int MovieId { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }


        public SeanceAddRequest ToSeanceAddRequest()
        {
            return new SeanceAddRequest()
            {
                MaxTickets = MaxTickets,
                AssignedAt = AssignedAt,
                MovieId = MovieId
            };
        }
        public SeanceUpdateRequest ToSeanceUpdateRequest() 
        {  
            return new SeanceUpdateRequest() 
            {
                Id = Id,
                MaxTickets = MaxTickets,
                AssignedAt = AssignedAt,
                MovieId = MovieId
            }; 
        }
    }
    public static class SeanceResponseExtensions
    {
        public static SeancesViewModel ToSeanceViewModel(this SeanceResponse seanceResponse)
        {
            return new SeancesViewModel()
            {
                Id= seanceResponse.Id,
                MaxTickets = seanceResponse.MaxTickets,
                AssignedAt = seanceResponse.AssignedAt,
                MovieId = seanceResponse.MovieId,
                Tickets = seanceResponse.Tickets
            };
        }
    }   
}