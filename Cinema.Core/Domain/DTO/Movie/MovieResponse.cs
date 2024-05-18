using Cinema.Core.Domain.DTO.Propositions;
using Cinema.Core.Domain.DTO.Seance;
using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Movie
{
    public class MovieResponse
    {
        public MovieResponse() {
            this.Seances = new HashSet<SeanceResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Trailers { get; set; } = null!;
        public string Actors { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime Duration { get; set; }
        public double Rating { get; set; }
        public ICollection<SeanceResponse>? Seances { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(MovieResponse)) return false;

            MovieResponse? toCompare = obj as MovieResponse;
            if (toCompare == null) return false;

            return toCompare.Id == Id &&
                toCompare.Name == Name &&
                toCompare.Description == Description;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        public MovieAddRequest ToAddRequest()
        {
            return new MovieAddRequest(Name, Description, Trailers, Actors, Genre, Duration, Rating);
        }
    }

    public static class MovieExtensions
    {
        public static MovieResponse ToMovieResponse(this Entities.Movie movie)
        {
            var movieResponse = new MovieResponse()
            {
                Id = movie.Id,
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
                movieResponse.Seances.Add(seance.ToSeanceResponse());
            }
            return movieResponse;
        }
    }
}
