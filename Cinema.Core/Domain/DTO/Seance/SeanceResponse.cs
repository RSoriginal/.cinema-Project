using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Core.Domain.Entities;

namespace Cinema.Core.Domain.DTO.Seance
{
    public class SeanceResponse
    {
        public SeanceResponse() { }

        public int Id { get; set; }
        public int MaxTickets { get; set; }
        public DateTime AssignedAt { get; set; }
        public int MovieId { get; set; }
        public ICollection<Entities.Ticket>? Ticket { get; set; }
    }

    public static class SeanceExtensions
    {
        public static SeanceResponse ToSeanceResponse(this Entities.Seance seance)
        {
            return new SeanceResponse
            {
                MaxTickets = seance.MaxTickets,
                AssignedAt = seance.AssignedAt,
                MovieId = seance.MovieId
            };
        }
    }
}