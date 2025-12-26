// aashis controller
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyNewMvc.Models;

namespace MyNewMvc.Controllers;

public class aashisController : Controller
{
    // private readonly ILogger<aashisController> _logger;

    // public aashisController(ILogger<aashisController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult aashis()
    {
        return View();
    }

     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}