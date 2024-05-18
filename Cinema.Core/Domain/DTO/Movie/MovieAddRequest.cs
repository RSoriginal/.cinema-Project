using Cinema.Core.Domain.DTO.Seance;
using Cinema.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.DTO.Movie
{
    public class MovieAddRequest
    {
        public MovieAddRequest()
        {
        }

        public MovieAddRequest(string name, string desc, string trailers, string actors, string genre, DateTime duration, double rating) {
            Name = name;
            Description = desc;
            Trailers = trailers;
            Actors = actors;
            Genre = genre;
            Duration = duration;
            Rating = rating;
        }

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
