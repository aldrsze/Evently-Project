using Microsoft.AspNetCore.Mvc;

namespace evently.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Bookings() => View();

    public IActionResult Favorites() => View();
}
