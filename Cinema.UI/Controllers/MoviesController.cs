using Cinema.Core.Domain.DTO.Movie;
using Cinema.Core.Domain.Entities.Enum;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.UI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cinema.UI.Controllers
{
    //[Route("[controller]/[action]")]
    public class MoviesController : Controller
    {
        private IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            return View((await _movieService.GetMoviesAsync()).Select(x => x.ToMovieViewModel()));
        }

        public async Task<IActionResult> Schedule(ScheduleSortOptions scheduleSort = ScheduleSortOptions.Today)
        {
            ViewBag.CurrentSort = scheduleSort;
            var movies = await _movieService.GetMoviesAsync();
            switch(scheduleSort)
            {
                case ScheduleSortOptions.Today:
                    movies = movies.Where(x => x.Seances.Where(y => y.AssignedAt.Day == DateTime.UtcNow.Day).Count() > 0).ToHashSet();
                    break;
                case ScheduleSortOptions.Tomorrow:
                    movies = movies.Where(x => x.Seances.Where(y => y.AssignedAt.Day == DateTime.UtcNow.Day+1).Count() > 0).ToHashSet();
                    break;
                case ScheduleSortOptions.NextWeek:
                    movies = movies.Where(x => x.Seances.Where(y => y.AssignedAt.Day == DateTime.UtcNow.Day+7).Count() > 0).ToHashSet();
                    break;
            }
            return View(movies);
        }
    }
}
