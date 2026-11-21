using Microsoft.AspNetCore.Mvc;

namespace evently.Controllers;

public class AdminController : Controller
{
    public IActionResult Index() => View();
}
