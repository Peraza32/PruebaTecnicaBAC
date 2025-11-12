

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VentasDemo.Services.Interfaces;
using VentasDemo.Models.ViewModels;
using VentasDemo.Models;

namespace VentasDemo.Controllers
{
    public class SaleController : Controller
    {
        private readonly IProductService _productService;
        private readonly VentasDemo.Services.Interfaces.ISalesService _salesService;

        public SaleController(IProductService productService, VentasDemo.Services.Interfaces.ISalesService salesService)
        {
            _productService = productService;
            _salesService = salesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Load sales from service and pass to view so the list is not empty
            var sales = _salesService.getAllSales();
            return View(sales);
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Provide products to the view for client-side search/selection
            var products = _productService.GetAllProducts();
            ViewData["Products"] = products;
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            var sale = _salesService.getSalebyId(id);
            if (sale == null)
            {
                return NotFound();
            }

            return View("SaleDetail", sale);
        }

        [HttpPost]
        public ActionResult RegisterSale(SaleViewModel model, string itemsJson)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Auth");
            }

            List<SaleDetailsViewModel> items = new List<SaleDetailsViewModel>();
            if (!string.IsNullOrWhiteSpace(itemsJson))
            {
                try
                {
                    items = JsonSerializer.Deserialize<List<SaleDetailsViewModel>>(itemsJson) ?? new List<SaleDetailsViewModel>();
                }
                catch
                {
                    TempData["ErrorMessage"] = "Invalid sale items.";
                    return RedirectToAction("NewSale");
                }
            }

            if (items.Count == 0)
            {
                TempData["ErrorMessage"] = "Please add at least one product to the sale.";
                return RedirectToAction("NewSale");
            }

            // Build sale entity and validate server-side (recalculate prices)
            var saleEntity = new Sale
            {
                UserId = 0,
                SaleDate = DateTime.UtcNow,
                ClientName = model.ClientName,
                TotalAmount = 0m,
                SaleDetails = new List<SaleDetails>()
            };

            // optional: try to get user id from session if available
            var userIdString = HttpContext.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out var uid))
            {
                saleEntity.UserId = uid;
            }

            decimal total = 0m;
            foreach (var it in items)
            {
                var product = _productService.GetProductById(it.ProductId);
                if (product == null)
                {
                    TempData["ErrorMessage"] = $"Product with id {it.ProductId} not found.";
                    return RedirectToAction("NewSale");
                }

                // use server price to avoid tampering
                var unitPrice = product.Price;

                // optional: check stock
                if (product.Stock < it.Quantity)
                {
                    TempData["ErrorMessage"] = $"Insufficient stock for product {product.Name}. Available: {product.Stock}.";
                    return RedirectToAction("NewSale");
                }

                var detail = new SaleDetails
                {
                    ProductId = it.ProductId,
                    Quantity = it.Quantity,
                    UnitPrice = unitPrice
                };
                saleEntity.SaleDetails.Add(detail);
                total += unitPrice * it.Quantity;
            }

            saleEntity.TotalAmount = total;

            try
            {
                var saved = _salesService.addSale(saleEntity);
                TempData["SuccessMessage"] = $"Sale registered (id={saved.Id}).";
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "An error occurred while saving the sale.";
                return RedirectToAction("NewSale");
            }

            return RedirectToAction("Index");
        }
    }
}
