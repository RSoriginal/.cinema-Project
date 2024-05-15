using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers
{
    //[Route("[controller]/[action]")]
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }
    }
}
