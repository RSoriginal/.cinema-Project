using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Movie
{
    public class MovieUpdateRequest
    {
        public MovieUpdateRequest()
        {
        }

        public MovieUpdateRequest(string name, string desc, string trailers, string actors, string genre, DateTime duration, double rating)
        {
            Name = name;
            Description = desc;
            Trailers = trailers;
            Actors = actors;
            Genre = genre;
            Duration = duration;
            Rating = rating;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Trailers { get; set; } = null!;
        public string Actors { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime Duration { get; set; }
        public double Rating { get; set; }

        public Entities.Movie ToMovie()
        {
            var movie = new Entities.Movie()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Actors = this.Actors,
                Genre = this.Genre,
                Duration = this.Duration,
                Rating = this.Rating,
                Trailers = this.Trailers
            };
            return movie;
        }
    }
}
