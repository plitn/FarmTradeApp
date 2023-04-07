using FarmTradeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class MyDocumentsController : Controller
{
    private readonly FarmTradeContext _context;

    public MyDocumentsController(FarmTradeContext context)
    {
        _context = context;
    }

    [Authorize]
    [Route("/MyDocuments")]
    public IActionResult MyDocuments(int id)
    {
        ViewData["catList"] = _context.Categories;
        var docsData = new UserAndDocumentsModel();
        docsData.user = _context.Users
            .First(x => x.user_id == id);
        docsData.Documents = _context.Documents.Where(x => x.user_id == docsData.user.user_id).ToList();
        return View(docsData);
    }

    [Authorize]
    [Route("/MyDocuments/DelDoc")]
    public IActionResult DelDoc(int id)
    {
        ViewData["catList"] = _context.Categories;
        var deletedDoc = _context.Documents.First(x => x.document_id == id);
        _context.Documents.Remove(deletedDoc);
        _context.SaveChanges();
        return Redirect("~/MyDocuments");
    }
}