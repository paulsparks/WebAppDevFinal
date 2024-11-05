// Paul Sparks

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Action = "Add";
        return View("Edit", new Movie());
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ViewBag.Action = "Edit";
        var movie = _context.Movies.Find(id);
        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            if (movie.MovieId == 0)
                _context.Movies.Add(movie);
            else
                _context.Movies.Update(movie);

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
            return View(movie);
        }
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        return View(movie);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var movies = _context.Movies.Include(m => m.Genre)
            .OrderBy(m => m.Name).ToList();
        return View(movies);
    }
}
