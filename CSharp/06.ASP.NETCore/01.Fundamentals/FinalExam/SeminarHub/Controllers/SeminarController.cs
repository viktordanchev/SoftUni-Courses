using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Categories;
using SeminarHub.Models.Seminars;
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
                    DateAndTime = s.DateAndTime.ToString(DataConstants.Seminar.DateAndTimeFormat),
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
            if(!DateTime.TryParseExact(
                model.DateAndTime, 
                DataConstants.Seminar.DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.Seminar.DateAndTimeFormat}.");
            }

            if(!ModelState.IsValid)
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
                OrganizerId = GetOrganizerId()
            };

            await _context.AddAsync(seminar );
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetOrganizerId()
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
