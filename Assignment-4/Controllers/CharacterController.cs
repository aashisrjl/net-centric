using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_4.Models;
using Assignment_4.Data;

namespace Assignment_4.Controllers
{
    public class CharacterController : Controller
    {
        private readonly AppDbContext _context;

        public CharacterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult characterlist()
        {
            var characters = _context.Character.ToList();
            return View(characters);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Character.Add(character);
                _context.SaveChanges();
                return RedirectToAction("characterlist");
            }
            return View(character);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var character = _context.Character.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        [HttpPost]
        public IActionResult Edit(int id, Character updatedCharacter)
        {
            var character = _context.Character.Find(id);
            if (character == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                character.MovieID = updatedCharacter.MovieID;
                character.ActorID = updatedCharacter.ActorID;
                character.CharacterName = updatedCharacter.CharacterName;
                character.Pay = updatedCharacter.Pay;
                character.Screentime = updatedCharacter.Screentime;
                _context.SaveChanges();
                return RedirectToAction("characterlist");
            }
            return View(updatedCharacter);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var character = _context.Character.Find(id);
            if (character != null)
            {
                _context.Character.Remove(character);
                _context.SaveChanges();
            }
            return RedirectToAction("characterlist");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}