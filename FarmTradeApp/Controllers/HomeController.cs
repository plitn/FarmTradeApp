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
    
    [Route("/")]
    public IActionResult Index()
    {
        Console.WriteLine(_context.Categories);
        ViewData["catList"] = _context.Categories;
        return View("Index", _context.Products);
    }

    [HttpGet]
    [Route("/Index")]
    public IActionResult Index(int cat)
    {
        ViewData["catList"] = _context.Categories;
        if (cat == 0)
        {
            return View("Index", _context.Products.ToList());
        }
        var selectedByCategory = _context.Products.Where(x => x.category == cat).ToList();
        if (!selectedByCategory.Any())
        {
            selectedByCategory = new List<Products>();
        }
        return View("Index", selectedByCategory);
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