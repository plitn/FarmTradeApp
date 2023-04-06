using System.Diagnostics;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class AddProductController : Controller
{
    private readonly FarmTradeContext _context;

    public AddProductController(FarmTradeContext context)
    {
        _context = context;
    }

    [Authorize]
    [Route("/AddProduct")]
    public IActionResult AddProduct()
    {
        var optionsModel = new AddProductOptionsModel();
        optionsModel.Categories = _context.Categories;
        optionsModel.WeightTypes = _context.WeightTypes;
        return View(optionsModel);
    }

    [HttpPost]
    [Authorize]
    public IActionResult ManageAdding()
    {
        IFormFile image = HttpContext.Request.Form.Files.GetFile("product-photo");
        // Generate a unique file name
        var fileExtension = Path.GetExtension(image.FileName);
        var uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmssfff}-{Guid.NewGuid()}{fileExtension}";

        var path = Path.Combine(
            Directory.GetCurrentDirectory(), "wwwroot", "images",
            uniqueFileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            image.CopyTo(stream);
        }
        var url = Url.Content($"~/images/{uniqueFileName}");
        Products newProduct = new Products();
        try
        {
            newProduct.product_id = _context.Products.OrderBy(x => x.product_id).Last().product_id + 1;
        }
        catch (Exception e)
        {
            newProduct.product_id = 1;
        }

        newProduct.name = HttpContext.Request.Form["product-name"];
        newProduct.user_id = int.Parse(User.FindFirst("user_id").Value);
        newProduct.description = HttpContext.Request.Form["product-description"];
        newProduct.photo = url;
        newProduct.category = _context.Categories
            .First(x => x.Category_id == int.Parse(HttpContext.Request.Form["product-category"])).Category_id;
        newProduct.weight = int.Parse(HttpContext.Request.Form["product-quantity"]);
        newProduct.price = int.Parse(HttpContext.Request.Form["product-price"]);
        newProduct.is_active = true;
        newProduct.weight_category = _context.Categories
            .First(x => x.Category_id == int.Parse(HttpContext.Request.Form["product-category"])).Category_id;
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return Redirect("~/AddProduct");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}