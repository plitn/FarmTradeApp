using System.Diagnostics;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class ProfileController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ProfileController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/Profile")]
    public IActionResult Profile()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}