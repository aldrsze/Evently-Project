using Microsoft.AspNetCore.Mvc;

namespace evently.Controllers;

public class BookingController : Controller
{
    public IActionResult Checkout() => View();

    public IActionResult Success() => View();
}
