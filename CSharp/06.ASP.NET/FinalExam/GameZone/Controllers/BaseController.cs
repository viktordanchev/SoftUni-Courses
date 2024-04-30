using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameZone.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string userId = string.Empty;

            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}
