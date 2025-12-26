// aashis controller
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_4.Models;
using Assignment_4.ViewModels;
using Assignment_4.Data;

namespace Assignment_4.Controllers;

public class MoviesController : Controller
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult movielist()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult create(Movies movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("movielist");
        }
        return View(movie);
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(int id, Movies updatedMovie)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            movie.Title = updatedMovie.Title;
            movie.Rating = updatedMovie.Rating;
            movie.Budget = updatedMovie.Budget;
            movie.Gross = updatedMovie.Gross;
            movie.ReleaseDate = updatedMovie.ReleaseDate;
            movie.Genre = updatedMovie.Genre;
            movie.Runtime = updatedMovie.Runtime;
            movie.Summary = updatedMovie.Summary;
            _context.SaveChanges();
            return RedirectToAction("movielist");
        }
        return View(updatedMovie);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        return RedirectToAction("movielist");
    }

    [HttpGet]
    public IActionResult Dashboard()
    {
        var topMovies = _context.Movies.Take(5).ToList();
        var topActors = _context.Actor.Take(5).ToList();
        var topCharacters = _context.Character.Take(5).ToList();

        var dashboardData = new DashboardViewModel
        {
            Movies = topMovies,
            Actors = topActors,
            Characters = topCharacters
        };
        return View(dashboardData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}