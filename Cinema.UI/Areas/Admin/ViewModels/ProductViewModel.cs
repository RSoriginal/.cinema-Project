using Cinema.Core.Domain.DTO.Movie;
using Cinema.Core.Domain.Entities;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreUI.Areas.Admin.ViewModels
{
    public sealed class MovieViewModel
    {
        public MovieViewModel()
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
        public ICollection<Seance>? Seances { get; set; }


        public MovieAddRequest ToMovieAddRequest()
        {
            return new MovieAddRequest() 
            {
                Name = Name,
                Description = Description,
                Trailers = Trailers,
                Actors = Actors,
                Genre = Genre,
                Duration = Duration,
                Rating = Rating
                //Seances = this.Seances.Select(x => x.T) TODO
            };
        }
        public MovieUpdateRequest ToMovieUpdateRequest()
        {
            return new MovieUpdateRequest()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Trailers = Trailers,
                Actors = Actors,
                Genre = Genre,
                Duration = Duration,
                Rating = Rating
                //Seances = this.Seances.Select(x => x.T) TODO
            };
        }
    }

    public static class MovieResponseExtensions
    {
        public static MovieViewModel ToMovieViewModel(this MovieResponse response)
        {
            return new MovieViewModel()
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                Trailers = response.Trailers,
                Actors = response.Actors,
                Genre = response.Genre,
                Duration = response.Duration,
                Rating = response.Rating,
                Seances = response.Seances
            };
        }
    }
}
