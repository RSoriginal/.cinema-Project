using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Core.Domain.Entities
{
    public class Seance
    {
        public Seance()
        {
            Tickets = new HashSet<Ticket>();            
        }
        public int Id { get; set; }
        public int MaxTickets { get; set; }
        public DateTime AssignedAt { get; set; }
        public int MovieId { get;set; }
        [ForeignKey(nameof(MovieId))]
        public Movie? Movie { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
