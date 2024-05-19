using Cinema.Core.Domain.Entities;
using Cinema.Core.Domain.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.UI.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly UserManager<CinemaUser> _userManager;
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;
        public TicketsController(UserManager<CinemaUser> userManager, ITicketService ticketService, IMovieService movieService)
        {
            _userManager = userManager;
            _ticketService = ticketService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Book(int ticketId)
        {
            if (await _ticketService.IsExistAsync(ticketId))
            {
                var ticket = await _ticketService.GetTicketAsync(ticketId);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ticket.UserId = Guid.Parse(userId);
                await _ticketService.UpdateTicketAsync(ticket.ToUpdateRequest());
            }
            return View();

        }
        public async Task<IActionResult> Index(int? movieId)
        {
            if (movieId == null) { return Redirect("/"); }
            return View((await _movieService.GetMovieAsync(movieId.Value)).Seances);
        }
    }
}
