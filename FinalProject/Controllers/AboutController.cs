// Paul Sparks

using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;

namespace FinalProject.Controllers;

public class AboutController : Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
