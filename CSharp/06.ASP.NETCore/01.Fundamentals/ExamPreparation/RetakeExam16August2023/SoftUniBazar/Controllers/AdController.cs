using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    public class AdController : Controller
    {
        private readonly BazarDbContext _data;

        public AdController(BazarDbContext data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var ads = await _data.Ads
                .Select(x => new AdViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Owner = x.Owner.UserName,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn.ToString(DataConstants.Ad.DateTimeFormat),
                    Category = x.Category.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return View(ads);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdViewModel();
            var categories = await GetAllCategoriesAsync();
            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdViewModel model)
        {
            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId,
                OwnerId = GetUserId(),
                CreatedOn = DateTime.Now
            };

            await _data.AddAsync(ad);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await _data.Ads
                .FirstAsync(a => a.Id == id);
            var categories = await GetAllCategoriesAsync();

            var model = new AdViewModel()
            {
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId
            };

            model.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdViewModel model)
        {
            var ad = await _data.Ads.FirstAsync(a => a.Id == model.Id);

            ad.Name = model.Name;
            ad.Description = model.Description;
            ad.ImageUrl = model.ImageUrl;
            ad.Price = model.Price;
            ad.CategoryId = model.CategoryId;

            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var buyerId = GetUserId();
            var ads = await _data.AdsBuyers
                .Where(ab => ab.BuyerId == buyerId)
                .Select(a => new AdViewModel()
                {
                    Name = a.Ad.Name,
                    ImageUrl = a.Ad.ImageUrl,
                    CreatedOn = a.Ad.CreatedOn.ToString(DataConstants.Ad.DateTimeFormat),
                    Category = a.Ad.Category.Name,
                    Description = a.Ad.Description,
                    Price = a.Ad.Price,
                    Owner = a.Ad.Owner.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            return View(ads);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = GetUserId();

            var adBuyer = new AdBuyer()
            {
                BuyerId = userId,
                AdId = id
            };

            await _data.AdsBuyers.AddAsync(adBuyer);
            await _data.SaveChangesAsync();

            return RedirectToAction("Cart", "Ad");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var adBuyer = await _data.AdsBuyers
                .FirstAsync(a => a.AdId == id);

            _data.AdsBuyers.Remove(adBuyer);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await _data.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
