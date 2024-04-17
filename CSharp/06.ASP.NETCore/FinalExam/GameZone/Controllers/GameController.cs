using GameZone.Data;
using GameZone.Models.Games;
using GameZone.Models.Genres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GameZone.Controllers
{
    public class GameController : BaseController
    {
        private readonly GameZoneDbContext _context;

        public GameController(GameZoneDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var seminars = await _context.Games
                .Select(s => new AllViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Genre = s.Genre.Name,
                    ImageUrl = s.ImageUrl,
                    ReleasedOn = s.ReleasedOn.ToString(DataConstants.Game.DateAndTimeFormat, CultureInfo.InvariantCulture),
                    Publisher = s.Publisher.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddViewModel();
            model.Genres = await GetAllGenresAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            DateTime dateAndTime;
            if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DataConstants.Game.DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DataConstants.Game.DateAndTimeFormat}.");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await GetAllGenresAsync();

                return View(model);
            }

            var game = new Data.Models.Game()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                ReleasedOn = dateAndTime,
                GenreId = model.GenreId,
                PublisherId = GetUserId()
            };

            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _context.Games
                .FirstAsync(g => g.Id == id);

            var model = new AddViewModel()
            {
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                ReleasedOn = game.ReleasedOn.ToString(DataConstants.Game.DateAndTimeFormat, CultureInfo.InvariantCulture),
                GenreId = game.GenreId,
                Genres = await GetAllGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddViewModel model)
        {
            var game = await _context.Games
                .FirstAsync(g => g.Id == id);

            DateTime dateAndTime;
            if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DataConstants.Game.DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.ReleasedOn), $"Invalid date! Format must be: {DataConstants.Game.DateAndTimeFormat}.");
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await GetAllGenresAsync();

                return View(model);
            }

            game.Title = model.Title;
            game.Description = model.Description;
            game.ImageUrl = model.ImageUrl;
            game.ReleasedOn = dateAndTime;
            game.GenreId = model.GenreId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var game = await _context.Games
                .Select(s => new DetailsViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    ReleasedOn = s.ReleasedOn.ToString(DataConstants.Game.DateAndTimeFormat, CultureInfo.InvariantCulture),
                    Description = s.Description,
                    Publisher = s.Publisher.UserName,
                    Genre = s.Genre.Name,
                    ImageUrl = s.ImageUrl
                })
                .FirstAsync(s => s.Id == id);

            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.Games
                .FirstAsync(s => s.Id == id);

            var model = new DeleteViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Publisher = game.Publisher.UserName
            };

            return View(model);
        }

        [HttpGet]
        private async Task<IEnumerable<GenreViewModel>> GetAllGenresAsync()
        {
            var genres = await _context.Genres
                .Select(c => new GenreViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return genres;
        }
    }
}
