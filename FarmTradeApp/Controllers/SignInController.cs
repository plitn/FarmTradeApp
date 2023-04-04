using System.Diagnostics;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class SignInController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public SignInController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/SignIn")]
    public IActionResult SignIn()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}