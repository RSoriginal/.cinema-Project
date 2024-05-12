using Cinema.Core.Domain.Entities;

namespace Cinema.Core.Domain.DTO.Seance
{
    public class SeanceUpdateRequest
    {
        public SeanceUpdateRequest() { }
        public SeanceUpdateRequest(int maxTickets, DateTime assignedAt, int movieId)
        {
            MaxTickets = maxTickets;
            AssignedAt = assignedAt;
            MovieId = movieId;
        }
        public int Id { get; set; }
        public int MaxTickets { get; set; }
        public DateTime AssignedAt { get; set; }
        public int MovieId { get; set; }
        public Entities.Seance ToSeance()
        {
            return new Entities.Seance()
            {
                Id = this.Id,
                MaxTickets = this.MaxTickets,
                AssignedAt = this.AssignedAt,
                MovieId = this.MovieId
            };
        }
    }
}