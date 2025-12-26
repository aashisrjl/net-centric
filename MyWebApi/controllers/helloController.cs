using Microsoft.AspNetCore.Mvc; // Required for ControllerBase and routing attributes
namespace MyWebApi.Controllers{
    [ApiController]
    [Route("api/[controller]")]

    public class HelloController : ControllerBase{
        [HttpGet]
        public IActionResult SayHello(){
            return Ok("hello, this is hello api");
        }
    }
}