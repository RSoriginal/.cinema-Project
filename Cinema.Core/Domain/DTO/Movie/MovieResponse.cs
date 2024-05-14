using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Movie
{
    public class MovieResponse
    {
        public MovieResponse() { }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Trailers { get; set; } = null!;
        public string Actors { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime Duration { get; set; }
        public double Rating { get; set; }
        public ICollection<Entities.Seance>? Seances { get; set; }
    }

    public static class MovieExtensions
    {
        public static MovieResponse ToMovieResponse(this Entities.Movie movie)
        {
            var movieResponse = new MovieResponse()
            {
                Name = movie.Name,
                Description = movie.Description,
                Actors = movie.Actors,
                Genre = movie.Genre,
                Duration = movie.Duration,
                Rating = movie.Rating,
                Trailers = movie.Trailers
            };

            foreach (var seance in movie.Seances)
            {
                movieResponse.Seances.Add(seance);
            }
            return movieResponse;
        }
    }
}
