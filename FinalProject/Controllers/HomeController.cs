// Paul Sparks

using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;

namespace FinalProject.Controllers;

public class HomeController : Controller
{
    private readonly RecipesContext _context;

    public HomeController(RecipesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Recipe(int id)
    {
        var recipe = _context.Recipes.Find(id);
        return View("Recipe", recipe);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var recipes = _context.Recipes.ToList();
        return View(recipes);
    }
}
