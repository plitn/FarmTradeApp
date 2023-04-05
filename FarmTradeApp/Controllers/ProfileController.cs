using System.Diagnostics;
using System.Security.Claims;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult Profile()
    {
        return View();
    }

    [Route("/LogOut")]
    public async Task<IActionResult> LogOutProfile()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("~/Index");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}