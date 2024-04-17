using GameZone.Data;
using GameZone.Data.Models;
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
                .Select(g => new DeleteViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName
                })
                .FirstAsync(s => s.Id == id);

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games
                .FirstAsync(s => s.Id == id);

            _context.Remove(game);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            var gamerGame = new GamerGame()
            {
                GameId = id,
                GamerId = GetUserId()
            };

            if (!await _context.GamersGames.ContainsAsync(gamerGame))
            {
                await _context.GamersGames.AddAsync(gamerGame);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(MyZone));
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var userId = GetUserId();

            var games = await _context.GamersGames
                .Where(gg => gg.GamerId == userId)
                .Select(gg => new JoinedViewModel()
                {
                    Id = gg.Game.Id,
                    Title = gg.Game.Title,
                    ImageUrl = gg.Game.ImageUrl,
                    Genre = gg.Game.Genre.Name,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(DataConstants.Game.DateAndTimeFormat, CultureInfo.InvariantCulture),
                    Publisher = gg.Game.Publisher.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            var gamerGame = await _context.GamersGames
                .FirstAsync(gg => gg.GameId == id);

            _context.Remove(gamerGame);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
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
