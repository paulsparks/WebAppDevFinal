// Paul Sparks

using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class AddRecipesController : Controller
{
    private readonly RecipesContext _context;

    public AddRecipesController(RecipesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var recipes = _context.Recipes.ToList();
        return View(recipes);
    }
}
