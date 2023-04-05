using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FarmTradeApp.Controllers;

public class SignUpController : Controller
{
    private readonly FarmTradeContext _context;

    public SignUpController(FarmTradeContext context)
    {
        _context = context;
    }

    [Route("/SignUp")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ManageSignUp()
    {
        //Console.WriteLine(_context.Users.ElementAt(0));
        var user = new Users();
        user.user_id = _context.Users.OrderBy(x => x.user_id).Last().user_id + 1;
        user.password = HttpContext.Request.Form["password"];
        user.address = HttpContext.Request.Form["addr"];
        user.first_name = HttpContext.Request.Form["name"];
        user.email = HttpContext.Request.Form["email"];
        user.profile_picture = "";
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