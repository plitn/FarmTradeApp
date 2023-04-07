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
        if (User.Identity.IsAuthenticated)
        {
            var favs = _context.Favourites
                .Where(x => x.user_id.ToString() == User.FindFirst("user_id").Value).ToList();
            p.IsFavourited = false;
            foreach (var item in favs)
            {
                if (item.product_id == id)
                {
                    p.IsFavourited = true;
                }
            }
        }

        return View(p);
    }

    [Authorize]
    [Route("/DeleteProduct")]
    public IActionResult DeleteProduct(int id)
    {
        ViewData["catList"] = _context.Categories;
        _context.Products.Remove(_context.Products.First(x => x.product_id == id));
        foreach (var fav in _context.Favourites)
        {
            if (fav.product_id == id)
            {
                _context.Favourites.Remove(fav);
            }
        }
        _context.SaveChanges();
        return Redirect("~/Profile");
    }

    [Authorize]
    [Route("/Product/UnFav")]
    public IActionResult UnFav(int id)
    {
        var neededProduct = _context.Products.First(x => x.product_id == id);
        var seller = _context.Users.First(x => x.user_id == neededProduct.user_id);
        var p = new ProductDataModel(neededProduct, seller);
        p.WeightType = _context.WeightTypes.First(x => x.Type_id == p.Product.weight_category);

        _context.Favourites.Remove(_context.Favourites
            .First(x => x.product_id == id &&
                        x.user_id.ToString() == User.FindFirst("user_id").Value));
        _context.SaveChanges();
        
        p.IsFavourited = false;

        return Redirect($"~/Product?id={id}");
    }
    
    [Authorize]
    [Route("/Product/Fav")]
    public IActionResult Fav(int id)
    {
        var neededProduct = _context.Products.First(x => x.product_id == id);
        var seller = _context.Users.First(x => x.user_id == neededProduct.user_id);
        var p = new ProductDataModel(neededProduct, seller);
        p.WeightType = _context.WeightTypes.First(x => x.Type_id == p.Product.weight_category);

        var favElem = new Favourites();
        favElem.product_id = id;
        favElem.user_id = int.Parse(User.FindFirst("user_id").Value);
        _context.Favourites.Add(favElem);
        _context.SaveChanges();
        
        p.IsFavourited = true;

        return Redirect($"~/Product?id={id}");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}