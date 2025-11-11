using Microsoft.AspNetCore.Mvc;
using VentasDemo.Models;

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
}