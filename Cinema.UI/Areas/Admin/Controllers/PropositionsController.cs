using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Cinema.Infrastructure.DBContext;

namespace Cinema.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class PropositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Propositions
        public async Task<IActionResult> Index()
        {
            var cinemaUIContext = _context.propositions.Include(p => p.Movie);
            return View(await cinemaUIContext.ToListAsync());
        }

        // GET: Admin/Propositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposition = await _context.propositions
                .Include(p => p.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposition == null)
            {
                return NotFound();
            }

            return View(proposition);
        }

        // GET: Admin/Propositions/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors");
            return View();
        }

        // POST: Admin/Propositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Discount,MovieId,UserId")] Proposition proposition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors", proposition.MovieId);
            return View(proposition);
        }

        // GET: Admin/Propositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposition = await _context.propositions.FindAsync(id);
            if (proposition == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors", proposition.MovieId);
            return View(proposition);
        }

        // POST: Admin/Propositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Discount,MovieId,UserId")] Proposition proposition)
        {
            if (id != proposition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropositionExists(proposition.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Set<Movie>(), "Id", "Actors", proposition.MovieId);
            return View(proposition);
        }

        // GET: Admin/Propositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposition = await _context.propositions
                .Include(p => p.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposition == null)
            {
                return NotFound();
            }

            return View(proposition);
        }

        // POST: Admin/Propositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposition = await _context.propositions.FindAsync(id);
            if (proposition != null)
            {
                _context.propositions.Remove(proposition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropositionExists(int id)
        {
            return _context.propositions.Any(e => e.Id == id);
        }
    }
}
