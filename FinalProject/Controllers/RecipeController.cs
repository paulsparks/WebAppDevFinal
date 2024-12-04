using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
  public class RecipeController : Controller
  {
    private RecipesContext context { get; set; }

    public RecipeController(RecipesContext ctx)
    {
      context = ctx;
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
      var recipe = context.Recipes.Find(id);
      return View(recipe);
    }

    [HttpPost]
    public IActionResult Edit(Recipe recipe)
    {
      if (ModelState.IsValid)
      {
        if (recipe.RecipeId == 0)
          context.Recipes.Add(recipe);
        else
          context.Recipes.Update(recipe);

        context.SaveChanges();
        return RedirectToAction("Index", "Home");
      }
      else
      {
        ViewBag.Action = (recipe.RecipeId == 0) ? "Add" : "Edit";
        return View(recipe);
      }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      var recipe = context.Recipes.Find(id);
      return View(recipe);
    }

    [HttpPost]
    public IActionResult Delete(Recipe recipe)
    {
      context.Recipes.Remove(recipe);
      context.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}
