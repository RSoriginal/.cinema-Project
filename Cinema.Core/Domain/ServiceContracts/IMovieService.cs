using Cinema.Core.Domain.DTO.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Domain.ServiceContracts
{
    public interface IMovieService
    {
        public Task<bool> IsExistAsync(int id);
        public Task<MovieResponse> GetMovieAsync(int id);
        public Task<ICollection<MovieResponse>> GetMoviesAsync();
        public Task<MovieResponse> CreateMovieAsync(MovieAddRequest movie);
        public Task<MovieResponse> UpdateMovieAsync(MovieUpdateRequest movie);
        public Task DeleteMovieAsync(int id);
    }
}
