using Microsoft.AspNetCore.Mvc; // Required for ControllerBase and routing attributes
namespace MyWebApi.Controller{
    [ApiController]
    
    [Route("api/greet")]


    public class greetController : ControllerBase{
        [HttpGet]
        public IActionResult greet(){
            return Ok("hi, this is greet");
        }
    }
}