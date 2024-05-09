using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Core.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SeanceId { get; set; }
        [ForeignKey(nameof(SeanceId))]
        public Seance? Seance { get; set; }
        public Guid UserId {  get; set; }
        [ForeignKey(nameof(UserId))]
        public CinemaUser? User { get; set; }
    }
}
