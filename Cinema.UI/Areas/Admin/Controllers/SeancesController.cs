using Cinema.Core.Domain.DTO.Seance;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.UI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Core.Domain.Entities;
using Cinema.Infrastructure.DBContext;
using Microsoft.AspNetCore.Authorization;


namespace Cinema.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SeancesController : Controller
    {
        private readonly ISeanceService _seanceService;
        private readonly IMovieService _movieService;
        private readonly ApplicationDbContext _context;

        public SeancesController(ISeanceService seanceService, IMovieService movieService, ApplicationDbContext context)
        {
            _seanceService = seanceService;
            _movieService = movieService;
            _context = context;
        }

        // GET: Admin/Seances
        public async Task<IActionResult> Index()
        {
            var seances = await _seanceService.GetSeancesAsync();            
            return View(seances.Select(s => s.ToSeanceViewModel()).ToList());
        }

        // GET: Admin/Seances/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var seance = await _seanceService.GetSeanceAsync(id);
            if (seance == null)
            {
                return NotFound();
            }            
            var seanceViewModel = seance.ToSeanceViewModel();  
            return View(seanceViewModel);
        }

        // GET: Admin/Seances/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.MovieId = new SelectList(_context.Set<Movie>(), "Id", "Name");
            return View();
        }

        // POST: Admin/Seances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaxTickets,AssignedAt,MovieId")] SeancesViewModel seancesViewModel)
        {
            if (ModelState.IsValid)
            {
                var seanceAddRequest = seancesViewModel.ToSeanceAddRequest();
                await _seanceService.CreateSeanceAsync(seanceAddRequest);
                return RedirectToAction(nameof(Index));
            }
            //ViewBag.MovieId = new SelectList(await _movieService.GetMoviesAsync(), "Id", "Name", seancesViewModel.MovieId);
            ViewBag.MovieId = new SelectList(_context.Set<Movie>(), "Id", "Name", seancesViewModel.MovieId);
            return View(seancesViewModel);
        }

        // GET: Admin/Seances/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var seance = await _seanceService.GetSeanceAsync(id);
            if (seance == null)
            {
                return NotFound();
            }
            var seancesViewModel = seance.ToSeanceViewModel();
            ViewBag.MovieId = new SelectList(_context.Set<Movie>(), "Id", "Name", seancesViewModel.MovieId);
            return View(seancesViewModel);
        }

        // POST: Admin/Seances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaxTickets,AssignedAt,MovieId")] SeancesViewModel seancesViewModel)
        {
            if (id != seancesViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var seanceUpdateRequest = seancesViewModel.ToSeanceUpdateRequest();
                    await _seanceService.UpdateSeanceAsync(seanceUpdateRequest);
                }
                catch (DbUpdateConcurrencyException)
                {       
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MovieId = new SelectList(_context.Set<Movie>(), "Id", "Name", seancesViewModel.MovieId);
            return View(seancesViewModel);
        }

        // GET: Admin/Seances/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var seance = await _seanceService.GetSeanceAsync(id);
            if (seance == null)
            {
                return NotFound();
            }
            var seanceViewModel = seance.ToSeanceViewModel();
            return View(seanceViewModel);
        }

        // POST: Admin/Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _seanceService.DeleteSeanceAsync(id);
            return RedirectToAction(nameof(Index));
        }        
    }
}
