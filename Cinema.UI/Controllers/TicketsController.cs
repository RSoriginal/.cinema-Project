using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
