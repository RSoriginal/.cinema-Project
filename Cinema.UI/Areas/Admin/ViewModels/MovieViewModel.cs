using Cinema.Core.Domain.DTO.Movie;
using Cinema.Core.Domain.DTO.Seance;
using Cinema.Core.Domain.Entities;
using Humanizer.Localisation;

namespace Cinema.UI.Areas.Admin.ViewModels
{
    public sealed class MovieViewModel
    {
        public MovieViewModel()
        {
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
