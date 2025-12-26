using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_4.Models;
using Assignment_4.Data;

namespace Assignment_4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var topMovies = _context.Movies.Take(5).ToList();
        var topActors = _context.Actor.Take(5).ToList();
        var topCharacters = _context.Character.Take(5).ToList();

        var dashboardData = new Assignment_4.ViewModels.DashboardViewModel
        {
            Movies = topMovies,
            Actors = topActors,
            Characters = topCharacters
        };
        return View(dashboardData);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
