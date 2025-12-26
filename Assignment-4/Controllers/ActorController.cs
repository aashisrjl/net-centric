using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_4.Models;
using Assignment_4.Data;
namespace Assignment_4.Controllers;

public class ActorController : Controller
{
    private readonly AppDbContext _context;

    public ActorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult actorlist()
    {
        var actors = _context.Actor.ToList();
        return View(actors);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Actor actor)
    {
        if (ModelState.IsValid)
        {
            _context.Actor.Add(actor);
            _context.SaveChanges();
            return RedirectToAction("actorlist");
        }
        return View(actor);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var actor = _context.Actor.Find(id);
        if (actor == null)
        {
            return NotFound();
        }
        return View(actor);
    }

    [HttpPost]
    public IActionResult Edit(int id, Actor updatedActor)
    {
        var actor = _context.Actor.Find(id);
        if (actor == null)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            actor.Name = updatedActor.Name;
            actor.DateOfBirth = updatedActor.DateOfBirth;
            actor.BirthCity = updatedActor.BirthCity;
            actor.BirthCountry = updatedActor.BirthCountry;
            actor.HeightInches = updatedActor.HeightInches;
            actor.Biography = updatedActor.Biography;
            actor.Gender = updatedActor.Gender;
            actor.NetWorth = updatedActor.NetWorth;
            _context.SaveChanges();
            return RedirectToAction("actorlist");
        }
        return View(updatedActor);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var actor = _context.Actor.Find(id);
        if (actor != null)
        {
            _context.Actor.Remove(actor);
            _context.SaveChanges();
        }
        return RedirectToAction("actorlist");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}