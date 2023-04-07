using System.Diagnostics;
using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class DocumentUploadController : Controller
{
    private readonly FarmTradeContext _context;

    public DocumentUploadController(FarmTradeContext context)
    {
        _context = context;
    }

    [Route("/DocumentUpload")]
    [Authorize]
    public IActionResult DocumentUpload()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public IActionResult ManageDoc()
    {
        var doc = new Document();
        doc.user_id = int.Parse(User.FindFirst("user_id").Value);
        if (_context.Documents.Any())
        {
            doc.document_id = _context.Documents.Count() + 1;
        }
        else
        {
            doc.document_id = 1;
        }
        doc.title = HttpContext.Request.Form["name"];
        
        
        IFormFile image = HttpContext.Request.Form.Files.GetFile("doc");
        // Generate a unique file name
        var fileExtension = Path.GetExtension(image.FileName);
        var uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmssfff}-{Guid.NewGuid()}{fileExtension}";

        var path = Path.Combine(
            Directory.GetCurrentDirectory(), "wwwroot", "docs",
            uniqueFileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            image.CopyTo(stream);
        }
        var url = Url.Content($"~/docs/{uniqueFileName}");

        doc.file_path = url;
        _context.Documents.Add(doc);
        _context.SaveChanges();
        return Redirect("~/DocumentUpload");
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}