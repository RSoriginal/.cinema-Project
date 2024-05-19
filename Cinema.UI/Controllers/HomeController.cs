using Cinema.Core.Domain.ServiceContracts;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> MovieReview(int? movieId)
        {
            if (movieId == null)
            {
                return View((await _movieService.GetMoviesAsync()).First());
            }

            if (await _movieService.IsExistAsync(movieId.Value))
            {
                return View(await _movieService.GetMovieAsync(movieId.Value));
            }

            return View((await _movieService.GetMoviesAsync()).First());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
