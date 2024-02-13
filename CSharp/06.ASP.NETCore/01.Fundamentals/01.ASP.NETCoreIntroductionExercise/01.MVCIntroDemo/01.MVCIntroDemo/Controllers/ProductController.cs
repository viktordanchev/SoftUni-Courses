using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models.Product;
using System.Text;
using System.Text.Json;

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
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50
                }
            };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var matchProducts = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                return View(matchProducts);
            }

            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var text = new StringBuilder();

            foreach (var product in products)
            {
                text.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }

            return Content(text.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            var text = new StringBuilder();

            foreach (var product in products)
            {
                text.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(text.ToString().TrimEnd()), "text/plain");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
