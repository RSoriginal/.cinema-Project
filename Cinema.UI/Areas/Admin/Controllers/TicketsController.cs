using Cinema.Core.Domain.DTO.Ticket;
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

        private async Task SetViewBags(int? selectedSeanceId = null, Guid? selectedUserId = null)
        {
            ViewBag.SeanceId = new SelectList(await _seanceService.GetSeancesAsync(), "Id", "AssignedAt", selectedSeanceId);
            ViewBag.UserId = new SelectList(_context.Set<CinemaUser>(), "Id", "UserName", selectedUserId);
        }

        // GET: TicketsController
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetTicketsAsync();
            var ticketViewModels = tickets.Select(ticket => ticket.ToTicketViewModel()).ToList();
            await SetViewBags();
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
            await SetViewBags();
            return View();
        }

        // POST: TicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketsViewModel ticketsViewModel)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < ticketsViewModel.NumberOfTickets; i++)
                {
                    var seatNumber = ticketsViewModel.SeatNumber + i;
                    var ticketAddRequest = new TicketAddRequest
                    {
                        SeatNumber = seatNumber,
                        Price = ticketsViewModel.Price,
                        IsAvailable = ticketsViewModel.IsAvailable,
                        SeanceId = ticketsViewModel.SeanceId,
                        UserId = ticketsViewModel.UserId
                    };
                    try
                    {
                        await _ticketService.CreateTicketAsync(ticketAddRequest);
                    }
                    catch (InvalidOperationException ex)
                    {
                        ModelState.AddModelError("", $"Error creating ticket for seat number {seatNumber}: {ex.Message}");
                        await SetViewBags(ticketsViewModel.SeanceId, ticketsViewModel.UserId);
                        return View(ticketsViewModel);
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            await SetViewBags(ticketsViewModel.SeanceId, ticketsViewModel.UserId);
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
            await SetViewBags(ticketViewModel.SeanceId, ticketViewModel.UserId);
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
            await SetViewBags(ticketsViewModel.SeanceId, ticketsViewModel.UserId);
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
