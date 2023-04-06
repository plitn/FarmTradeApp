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
    private readonly FarmTradeContext _context;

    public ProfileController(FarmTradeContext context)
    {
        _context = context;
    }

    [HttpGet("/Profile")]
    [Authorize]
    public IActionResult Profile()
    {
        var profileProducts = _context.Products
            .Where(x => x.user_id == int.Parse(User.FindFirst("user_id").Value))
            .ToList();
        var userData = new UserAndProductsModel();
        userData.user = _context.Users
            .First(x => x.user_id.ToString() == User.FindFirst("user_id").Value);
        userData.Products = profileProducts;
        return View(userData);
    }
    
    [HttpGet("/Profile/{id}")]
    public IActionResult Profile(int id)
    {
        if (id == int.Parse(User.FindFirst("user_id").Value))
        {
            Redirect("~/Profile");
        }

        // ПРОВЕРЯЕМ ЧТО ПОЛЬЗОВАТЕЛЬ СУЩЕСТВУЕТ CСДЕЛАТЬ
        
        var profileProducts = _context.Products
            .Where(x => x.user_id == id)
            .ToList();
        var userData = new UserAndProductsModel();
        userData.user = _context.Users
            .First(x => x.user_id == id);
        userData.Products = profileProducts;
        return View(userData);
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