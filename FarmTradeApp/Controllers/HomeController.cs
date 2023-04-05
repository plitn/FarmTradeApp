using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FarmTradeApp.Models;

namespace FarmTradeApp.Controllers;

public class HomeController : Controller
{
    private readonly FarmTradeContext _context;

    public HomeController(FarmTradeContext ftContext)
    {
        _context = ftContext;
    }

    public IActionResult Index()
    {
        return View("Index", _context.Products);
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