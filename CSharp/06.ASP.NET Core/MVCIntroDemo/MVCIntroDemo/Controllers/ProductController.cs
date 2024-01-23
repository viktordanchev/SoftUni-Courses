using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.Product;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>
            { 
                new ProductViewModel
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00
                },
                new ProductViewModel
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50
                },
                new ProductViewModel
                {
                    Id = 1,
                    Name = "Bread",
                    Price = 1.50
                }
            };

        public IActionResult All()
        {
            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = products
                .FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
