using Microsoft.AspNetCore.Mvc;

namespace FarmTradeApp.Controllers;

public class ErrorController : Controller
{
    [Route("/Error")]
    public IActionResult Error()
    {
        return View();
    }
    
    [Route("/Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        switch (statusCode)
        {
            case 404:
                ViewBag.ErrorMessage = "Sorry, the page you requested could not be found.";
                break;
            default:
                ViewBag.ErrorMessage = "An error occurred. Please try again later.";
                break;
        }

        return View("Error");
    }
}