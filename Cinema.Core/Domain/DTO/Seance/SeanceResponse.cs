using Cinema.Core.Domain.DTO.Movie;
using Cinema.Core.Domain.DTO.Ticket;
using Cinema.Core.Domain.Entities;
using System.Text.Json;
using System.Xml.Linq;

namespace Cinema.Core.Domain.DTO.Seance
{
    public class SeanceResponse
    {
        public SeanceResponse() { }

        public int Id { get; set; }
        public int MaxTickets { get; set; }
        public DateTime AssignedAt { get; set; }
        public int MovieId { get; set; }
        public ICollection<Entities.Ticket>? Tickets { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        public SeanceAddRequest ToAddRequest()
        {
            return new SeanceAddRequest(MaxTickets, AssignedAt, MovieId);
        }
    }

    public static class SeanceExtensions
    {
        public static SeanceResponse ToSeanceResponse(this Entities.Seance seance)
        {
            return new SeanceResponse
            {
                Id = seance.Id,
                MaxTickets = seance.MaxTickets,
                AssignedAt = seance.AssignedAt,
                MovieId = seance.MovieId,
                Tickets = seance.Tickets
            };
        }
    }
}