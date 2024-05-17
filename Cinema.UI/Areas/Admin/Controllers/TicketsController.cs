using Cinema.Core.Domain.Entities;
using Cinema.Core.Domain.ServiceContracts;
using Cinema.Infrastructure.DBContext;
using Cinema.UI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cinema.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public sealed class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ISeanceService _seanceService;
        private readonly ApplicationDbContext _context;
        public TicketsController(ITicketService ticketService, ISeanceService seanceService, ApplicationDbContext context)
        {
            _ticketService = ticketService;
            _seanceService = seanceService;
            _context = context;
        }
        // GET: TicketsController
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetTicketsAsync();
            var ticketViewModels = new List<TicketsViewModel>();
            foreach (var ticket in tickets)
            {
                ticketViewModels.Add(ticket.ToTicketViewModel());
            }
            return View(ticketViewModels);
        }

        // GET: TicketsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _ticketService.GetTicketAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            var ticketViewModel = ticket.ToTicketViewModel();
            return View(ticketViewModel);
        }

        // GET: TicketsController/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["SeanceId"] = new SelectList(await _seanceService.GetSeancesAsync(), "Id", "Actors");
            ViewBag.SeanceId = new SelectList(_context.Set<Seance>(), "Id", "Movie");
            ViewBag.UserId = new SelectList(_context.Set<CinemaUser>(), "Id", "UserName");
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketsViewModel ticketsViewModel)
        {
            if (ModelState.IsValid)
            {
                var ticketAddRequest = ticketsViewModel.ToTicketAddRequest();
                await _ticketService.CreateTicketAsync(ticketAddRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SeanceId = new SelectList(_context.Set<Seance>(), "Id", "Movie", ticketsViewModel.SeanceId);
            ViewBag.UserId = new SelectList(_context.Set<CinemaUser>(), "Id", "UserName", ticketsViewModel.UserId);
            return View(ticketsViewModel);            
        }

        // GET: TicketsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.GetTicketAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            var ticketViewModel = ticket.ToTicketViewModel();
            return View(ticketViewModel);
        }

        // POST: TicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TicketsViewModel ticketsViewModel)
        {
            if ( id != ticketsViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var ticketUpdateRequest = ticketsViewModel.ToTicketUpdateRequest();
                await _ticketService.UpdateTicketAsync(ticketUpdateRequest);
                return RedirectToAction(nameof(Index));
            }
            return View(ticketsViewModel);
        }

        // GET: TicketsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticketService.GetTicketAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            var ticketViewModel = ticket.ToTicketViewModel();
            return View(ticketViewModel);
        }

        // POST: TicketsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
