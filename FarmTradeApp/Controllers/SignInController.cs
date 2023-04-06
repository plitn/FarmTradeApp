using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FarmTradeApp.Controllers;

public class SignInController : Controller
{
    private readonly FarmTradeContext _context;

    public SignInController(FarmTradeContext context)
    {
        _context = context;
    }

    [Route("/SignIn")]
    public IActionResult SignIn()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ProcessSignIn()
    {
       
        var password = HttpContext.Request.Form["password"];
        var email = HttpContext.Request.Form["email"];
        Users user;
        try
        {
            user = _context.Users.First(x => x.password == password.ToString() && x.email == email.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("user not found");
            return Redirect("~/SignIn");
        }

        var claims = new List<Claim>
        {
            new Claim("user_id", user.user_id.ToString()),
            new Claim("user_name", user.first_name),
            new Claim("address", user.address),
            new Claim("email", user.email)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        return Redirect("~/Index");
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}