using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Models;

namespace SeminarHub.Controllers
{
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext _context;

        public SeminarController(SeminarHubDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var seminars = await _context.Seminars
                .Select(s => new SeminarAllViewModel()
                {
                    Id = s.Id,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat),
                    Organizer = s.Organizer.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(seminars);
        }
    }
}
