using Microsoft.AspNetCore.Mvc;

namespace evently.Controllers;

public class OrganizerController : Controller
{
    public IActionResult Index() => View();

    public IActionResult CreateEvent() => View();
}
