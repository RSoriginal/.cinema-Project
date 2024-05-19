using Cinema.Infrastructure.DBContext;
using Cinema.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int seanceId)
    {
        var seance = await _context.seances
            .Include(s => s.Movie)
            .Include(s => s.Tickets)
            .FirstOrDefaultAsync(s => s.Id == seanceId);

        if (seance == null)
        {
            return NotFound();
        }

        var viewModel = new BookingViewModel
        {
            Movie = seance.Movie,
            Tickets = seance.Tickets.ToList(),
            Seance = seance
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Reserve(int ticketId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket == null)
        {
            return NotFound();
        }

        ticket.IsAvailable = false;
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", new { seanceId = ticket.SeanceId });
    }
}

