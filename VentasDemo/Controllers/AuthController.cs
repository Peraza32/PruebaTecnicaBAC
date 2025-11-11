using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VentasDemo.Helpers;
using VentasDemo.Models;
using VentasDemo.Models.ViewModels;

namespace VentasDemo.Controllers;

public class AuthController:Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            {
                return View(model);
            }

        var hashedPassword = EncrypionHelper.EncryptPassword(model.Password);

        var user = _context.Users
            .FirstOrDefault(u => u.Username == model.Username && u.Password == hashedPassword);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            return View(model);
        }

        HttpContext.Session.SetString("Username", user.Username);
        HttpContext.Session.SetString("Role", user.Role);

        if (user.Role == "admin")
            return RedirectToAction("Index", "Home");
        else
            return RedirectToAction("Index", "Home");
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Auth");
    }
}