using System.Security.Claims;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class FavouritesController : Controller
{
    private readonly FarmTradeContext _context;

    public FavouritesController(FarmTradeContext context)
    {
        _context = context;
    }

    [Route("/Favourites")]
    [Authorize]
    public IActionResult Favourites()
    {
        ViewData["catList"] = _context.Categories;
        var favouriteProducts = new UserAndProductsModel();
        var selectFav = _context.Favourites
            .Where(x => x.user_id.ToString() == User.FindFirst("user_id").Value)
            .ToList();
        List<int> favProductsIds = new List<int>();
        foreach (var item in selectFav)
        {
            favProductsIds.Add(item.product_id);
        }

        favouriteProducts.Products = _context.Products
            .Where(x => favProductsIds.Contains(x.product_id));
        favouriteProducts.user = _context.Users
            .First(x => x.user_id.ToString() == User.FindFirst("user_id").Value);
        return View(favouriteProducts);
    }
}