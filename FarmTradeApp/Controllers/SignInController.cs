using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FarmTradeApp.Models;
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
    public IActionResult ProcessSignIn([FromBody] LoginDataModel ldm)
    {
        return Redirect("~/Index");
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}