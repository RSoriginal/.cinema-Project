using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Core.Domain.Entities;
using Cinema.Infrastructure.DBContext;
using Microsoft.AspNetCore.Authorization;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.UI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Cinema.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly UserManager<CinemaUser> _userManager;

        public MoviesController(IMovieService movieService, UserManager<CinemaUser> userManager)
        {
            _movieService = movieService;
            _userManager = userManager;
        }

        // GET: Admin/Movies
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMoviesAsync();
            return View(movies.Select(x => x.ToMovieViewModel()));
        }

        // GET: Admin/Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !await _movieService.IsExistAsync(id.Value))
            {
                return NotFound();
            }

            var movie = await _movieService.GetMovieAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie.ToMovieViewModel());
        }

        // GET: Admin/Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Trailers,Actors,Genre,Duration,Rating")] MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieAddRequest = movie.ToMovieAddRequest();
                await _movieService.CreateMovieAsync(movieAddRequest);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Admin/Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !await _movieService.IsExistAsync(id.Value))
            {
                return NotFound();
            }

            var movie = await _movieService.GetMovieAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie.ToMovieViewModel());
        }

        // POST: Admin/Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Trailers,Actors,Genre,Duration,Rating")] MovieViewModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _movieService.UpdateMovieAsync(movie.ToMovieUpdateRequest());
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _movieService.IsExistAsync(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Admin/Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !await _movieService.IsExistAsync(id.Value))
            {
                return NotFound();
            }

            var movie = await _movieService.GetMovieAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie.ToMovieViewModel());
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            if (movie != null)
            {
                await _movieService.DeleteMovieAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
