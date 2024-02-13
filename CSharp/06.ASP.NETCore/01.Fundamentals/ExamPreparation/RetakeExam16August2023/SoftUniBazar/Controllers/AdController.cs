using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;

namespace SoftUniBazar.Controllers
{
    public class AdController : Controller
    {
        private readonly BazarDbContext _data;

        public AdController(BazarDbContext data)
        {
            _data = data;
        }

        public async Task<IActionResult> All()
        {
            var ads = await _data.Ads
                .Select(x => new AdViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Owner = x.Owner,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                    Category = x.Category
                })
                .AsNoTracking()
                .ToListAsync();

            return View(ads);
        }

        public async Task<IActionResult> Add(AdViewModel model)
        {
            model.Categories = await _data.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToListAsync();

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.Now
            };

            await _data.Ads.AddAsync(ad);
            await _data.SaveChangesAsync();

            return View(model);
        }
    }
}
