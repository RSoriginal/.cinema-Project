using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Core.Domain.Entities;
using Cinema.Infrastructure.DBContext;

namespace Cinema.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Seances
        public async Task<IActionResult> Index()
        {
            var cinemaUIContext = _context.seances.Include(s => s.Movie);
            return View(await cinemaUIContext.ToListAsync());
        }

        // GET: Admin/Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.seances
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // GET: Admin/Seances/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors");
            return View();
        }

        // POST: Admin/Seances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaxTickets,AssignedAt,MovieId")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors", seance.MovieId);
            return View(seance);
        }

        // GET: Admin/Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.seances.FindAsync(id);
            if (seance == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors", seance.MovieId);
            return View(seance);
        }

        // POST: Admin/Seances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaxTickets,AssignedAt,MovieId")] Seance seance)
        {
            if (id != seance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(seance.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors", seance.MovieId);
            return View(seance);
        }

        // GET: Admin/Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seance = await _context.seances
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seance == null)
            {
                return NotFound();
            }

            return View(seance);
        }

        // POST: Admin/Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seance = await _context.seances.FindAsync(id);
            if (seance != null)
            {
                _context.seances.Remove(seance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeanceExists(int id)
        {
            return _context.seances.Any(e => e.Id == id);
        }
    }
}
