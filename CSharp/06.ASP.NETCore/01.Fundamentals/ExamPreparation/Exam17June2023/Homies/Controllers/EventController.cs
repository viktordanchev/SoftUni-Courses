﻿using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext _context;

        public EventController(HomiesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await _context.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DataConstants.Event.DateTimeFormat),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventViewModel();
            var types = await GetAllCategoriesAsync();

            model.Types = types;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventViewModel model)
        {
            DateTime start;
            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.Event.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.Event.DateTimeFormat}.");
            }

            DateTime end;
            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.Event.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.Event.DateTimeFormat}.");
            }

            var currEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = start,
                End = end,
                CreatedOn = DateTime.Now,
                TypeId = model.TypeId,
                OrganiserId = GetOrganiserId()
            };

            await _context.Events.AddAsync(currEvent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currEvent = await _context.Events
                .FirstAsync(e => e.Id == id);

            var model = new EventViewModel()
            {
                Name = currEvent.Name,
                Description = currEvent.Description,
                Start = currEvent.Start.ToString(DataConstants.Event.DateTimeFormat),
                End = currEvent.End.ToString(DataConstants.Event.DateTimeFormat),
                TypeId = currEvent.TypeId,
                Types = await GetAllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventViewModel model)
        {
            var currEvent = await _context.Events
                .FirstAsync(e => e.Id == id);

            DateTime start;
            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.Event.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.Event.DateTimeFormat}.");
            }

            DateTime end;
            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.Event.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.Event.DateTimeFormat}.");
            }

            currEvent.Name = model.Name;
            currEvent.Description = model.Description;
            currEvent.Start = start;
            currEvent.End = end;
            currEvent.TypeId = model.TypeId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = GetOrganiserId();
            var joinedEvents = await _context.EventsParticipants
                .Where(p => p.HelperId == userId)
                .Select(e => new EventViewModel()
                {
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString(DataConstants.Event.DateTimeFormat),
                    Type = e.Event.Type.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return View(joinedEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var eventParticipant = new EventParticipant()
            {
                HelperId = GetOrganiserId(),
                EventId = id
            };

            if(!_context.EventsParticipants.Contains(eventParticipant))
            {
                await _context.EventsParticipants.AddAsync(eventParticipant);
                await _context.SaveChangesAsync();
            }

            return View("Joined");
        }

        private string GetOrganiserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<IEnumerable<TypeViewModel>> GetAllCategoriesAsync()
        {
            return await _context.Types
                .Select(c => new TypeViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}