using Microsoft.AspNetCore.Mvc; // Required for ControllerBase and routing attributes

namespace MyWebApi.Controllers // Namespace should match your project name
{
    // This attribute tells ASP.NET Core that this class is an API controller
    [ApiController]

    // Defines the base route for this controller — will be "api/hello"
    [Route("api/[controller]")]

    // Inherits from ControllerBase to access Ok(), BadRequest(), etc.
    public class AashisController : ControllerBase
    {
        // This is a GET endpoint — accessed by visiting GET /api/hello
        [HttpGet]
        public IActionResult SayHello()
        {
            // Returns a 200 OK response with a message
            return Ok("Hello from Aashis's clean Web API! 🚀");
        }
    }
}
