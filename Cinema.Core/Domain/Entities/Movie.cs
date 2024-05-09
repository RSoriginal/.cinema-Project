using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Core.Domain.Entities
{
    public class Movie
    {
        public Movie()
        {
            Seances = new HashSet<Seance>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Trailers { get; set; } = null!;
        public string Actors { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime Duration { get; set; }
        public double Rating { get; set; }
        public ICollection<Seance> Seances { get; set; }

    }
}
