// Paul Sparks

using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class HomeController : Controller
{
    private readonly RecipesContext _context;

    public HomeController(RecipesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Action = "Add";
        return View("Edit", new Recipe());
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Action = "Edit";
        var recipe = _context.Recipes.Find(id);
        return View(recipe);
    }

    [HttpPost]
    public IActionResult Edit(Recipe recipe)
    {
        if (ModelState.IsValid)
        {
            if (recipe.RecipeId == 0)
                _context.Recipes.Add(recipe);
            else
                _context.Recipes.Update(recipe);

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Action = (recipe.RecipeId == 0) ? "Add" : "Edit";
            return View(recipe);
        }
    }

    [HttpPost]
    public IActionResult Delete(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recipe = _context.Recipes.Find(id);
        return View(recipe);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var recipes = _context.Recipes.ToList();
        return View(recipes);
    }
}
