using Microsoft.AspNetCore.Mvc;
using VentasDemo.Services.Interfaces;

namespace VentasDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Products()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }
            var products = _productService.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Models.ViewModels.AddProductViewModel model)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }


            if (ModelState.IsValid)
            {
                var product = new Models.Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Stock = model.Stock
                };

                _productService.AddProduct(product);
                return RedirectToAction("Products");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new Models.Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(int id, Models.ViewModels.AddProductViewModel model)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            if (ModelState.IsValid)
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Stock = model.Stock;

                _productService.UpdateProduct(product);
                return RedirectToAction("Products");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) &&
            string.IsNullOrEmpty(HttpContext.Session.GetString("Role")))
            {
                return RedirectToAction("Login", "Auth");
            }

            if(HttpContext.Session.GetString("Role") != "admin")
            {
                TempData["ErrorMessage"] = "You do not have permission for this action.";
                return RedirectToAction("Ventas");
            }

            _productService.DeleteProduct(id);
            return RedirectToAction("Products");
        }
    }
}