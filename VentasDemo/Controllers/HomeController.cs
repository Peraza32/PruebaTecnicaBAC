using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VentasDemo.Models;

namespace VentasDemo.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return RedirectToAction("Login", "Auth");
        }
        var role = HttpContext.Session.GetString("Role");
        // If not admin, redirect directly to Sales index page
        if (string.IsNullOrEmpty(role) || role.ToLower() != "admin")
        {
            return RedirectToAction("Index", "Sale");
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
