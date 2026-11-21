using Microsoft.AspNetCore.Mvc;

namespace evently.Controllers;

public class EventsController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Details(string id)
    {
        ViewData["EventId"] = id ?? string.Empty;
        return View();
    }
}
