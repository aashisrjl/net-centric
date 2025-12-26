// aashis controller
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyNewMvc.Models;

namespace MyNewMvc.Controllers;

public class MusicController : Controller
{
    [HttpGet]
    public IActionResult create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult create(MusicModel music)
    {
        if (ModelState.IsValid)
        {
            // Here you would typically save the music model to a database
            // For now, we will just return the model back to the view
            return View("Details", music);
        }
        return View(music);
    }



     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}