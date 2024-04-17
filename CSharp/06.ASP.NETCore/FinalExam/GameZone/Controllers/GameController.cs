using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GameController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
