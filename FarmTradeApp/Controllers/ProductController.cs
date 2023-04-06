using System.Diagnostics;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class ProductController :Controller
{
    private readonly FarmTradeContext _context;

    public ProductController(FarmTradeContext context)
    {
        _context = context;
    }

    [Route("/Product")]
    [HttpGet]
    public IActionResult Product(int id)
    {
        ViewData["catList"] = _context.Categories;
        if (id == null || id < 0 || !_context.Products.Any(x => x.product_id == id))
        {
            Redirect("~/Index");
        }

        var neededProduct = _context.Products.First(x => x.product_id == id);
        var seller = _context.Users.First(x => x.user_id == neededProduct.user_id);
        var p = new ProductDataModel(neededProduct, seller);
        p.WeightType = _context.WeightTypes.First(x => x.Type_id == p.Product.weight_category);
        return View(p);
    }

    [Authorize]
    [Route("/DeleteProduct")]
    public IActionResult DeleteProduct(int id)
    {
        ViewData["catList"] = _context.Categories;
        _context.Products.Remove(_context.Products.First(x => x.product_id == id));
        _context.SaveChanges();
        return Redirect("~/Profile");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}