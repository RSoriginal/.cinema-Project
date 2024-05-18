using Cinema.Core.Domain.Entities;

namespace Cinema.Core.Domain.DTO.Seance
{
    public class SeanceAddRequest
    {
        public SeanceAddRequest()
        {
            
        }
        public SeanceAddRequest(int maxTickets, DateTime assignedAt, int movieId)
        {
            MaxTickets = maxTickets;
            AssignedAt = assignedAt;
            MovieId = movieId;
        }
        public int MaxTickets { get; set;}
        public DateTime AssignedAt { get; set;}
        public int MovieId { get; set;}

        public Entities.Seance ToSeance()
        {
            return new Entities.Seance
            {
                MaxTickets = this.MaxTickets,
                AssignedAt = this.AssignedAt,
                MovieId = this.MovieId
            };
        }
    }
}