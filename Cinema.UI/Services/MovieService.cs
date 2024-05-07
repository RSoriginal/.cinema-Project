using Cinema.Core.Domain.DTO.Movie;
using Cinema.Core.Domain.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Infrastructure;
using Cinema.Infrastructure.DBContext;
using Cinema.Core.Domain.Entities;

namespace Cinema.UI.Services
{
    public sealed class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context) => _context = context;
        public async Task<MovieResponse> CreateMovieAsync(MovieAddRequest movie)
        {
            var dbMovie = movie.ToMovie();
            var seances = new List<Seance>();
            seances.AddRange(dbMovie.Seances.ToList());
            dbMovie.Seances.Clear();

            foreach (var i in seances)
            {
                dbMovie.Seances.Add(_context.seances.Where(x => x.MaxTickets == i.MaxTickets && x.AssignedAt == i.AssignedAt).First());
            }
            await _context.Movies.AddAsync(dbMovie);
            await _context.SaveChangesAsync();
            return dbMovie.ToMovieResponse();
        }

        public async Task DeleteMovieAsync(int id)
        {
            _context.Movies.Remove(await _context.Movies.FindAsync(id) ?? throw new ArgumentException("Invalid product response"));
            await _context.SaveChangesAsync();
        }

        public async Task<MovieResponse> GetMovieAsync(int id)
        {
            var context = _context.Movies.Include(x => x.Seances);
            var movie = await context.FirstOrDefaultAsync() ?? throw new ArgumentException($"Not possible to find a product by id:{id}", nameof(id));
            return movie.ToMovieResponse();
        }

        public async Task<ICollection<MovieResponse>> GetMoviesAsync()
        {
            var context = _context.Movies.Include(x => x.Seances);
            return await context.Select(x => x.ToMovieResponse()).ToListAsync();
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _context.Movies.AnyAsync(e => e.Id == id);
        }

        public async Task<MovieResponse> UpdateMovieAsync(MovieUpdateRequest movie)
        {
            var dbMovie = movie.ToMovie();
            _context.Movies.Update(dbMovie);
            await _context.SaveChangesAsync();
            return dbMovie.ToMovieResponse();
        }
    }
}
