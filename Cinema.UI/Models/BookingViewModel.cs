using Cinema.Core.Domain.Entities;

namespace Cinema.UI.Models
{
    public class BookingViewModel
    {
        public Movie Movie { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Seance Seance { get; set; }
    }
}
