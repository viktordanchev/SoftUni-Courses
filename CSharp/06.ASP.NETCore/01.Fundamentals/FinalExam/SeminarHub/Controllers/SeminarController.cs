using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Categories;
using SeminarHub.Models.Seminars;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Security.Claims;

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
                    DateAndTime = s.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat, CultureInfo.InvariantCulture),
                    Organizer = s.Organizer.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarAddViewModel();
            model.Categories = await GetAllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarAddViewModel model)
        {
            DateTime dateAndTime;
            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.Seminar.DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.Seminar.DateAndTimeFormat}.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetAllCategoriesAsync();

                return View(model);
            }

            var seminar = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = dateAndTime,
                Duration = model.Duration,
                CategoryId = model.CategoryId,
                OrganizerId = GetUserId()
            };

            await _context.Seminars.AddAsync(seminar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await _context.Seminars
                .FirstAsync(s => s.Id == id);

            var model = new SeminarAddViewModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat, CultureInfo.InvariantCulture),
                Duration = seminar.Duration,
                CategoryId = seminar.CategoryId,
                Categories = await GetAllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SeminarAddViewModel model)
        {
            var seminar = await _context.Seminars
                .FirstAsync(s => s.Id == id);

            DateTime dateAndTime;
            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.Seminar.DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.Seminar.DateAndTimeFormat}.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetAllCategoriesAsync();

                return View(model);
            }

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateAndTime;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var seminar = await _context.Seminars
                .Select(s => new SeminarDetailsViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat, CultureInfo.InvariantCulture),
                    Duration = s.Duration,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    Details = s.Details,
                    Organizer = s.Organizer.UserName
                })
                .FirstAsync(s => s.Id == id);

            return View(seminar);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await _context.Seminars
                .FirstAsync(s => s.Id == id);

            var model = new SeminarDeleteViewModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat, CultureInfo.InvariantCulture)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id, SeminarDeleteViewModel model)
        {
            var seminar = await _context.Seminars
                .FirstAsync(s => s.Id == id);

            _context.Remove(seminar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminarParticipant = new SeminarParticipant()
            {
                SeminarId = id,
                ParticipantId = GetUserId()
            };

            if (!await _context.SeminarsParticipants.ContainsAsync(seminarParticipant))
            {
                await _context.SeminarsParticipants.AddAsync(seminarParticipant);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Joined));
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var seminarParticipant = await _context.SeminarsParticipants
                .FirstAsync(sp => sp.SeminarId == id);

            _context.Remove(seminarParticipant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();

            var seminars = await _context.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .Select(sp => new SeminarJoinedViewModel() 
                { 
                    Id = sp.Seminar.Id,
                    Topic = sp.Seminar.Topic,
                    Lecturer = sp.Seminar.Lecturer,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat, CultureInfo.InvariantCulture),
                    Organizer = sp.Seminar.Organizer.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(seminars);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        private async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return categories;
        }
    }
}
