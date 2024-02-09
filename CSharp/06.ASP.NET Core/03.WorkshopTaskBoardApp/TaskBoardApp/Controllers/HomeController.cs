using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
