using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Greetings_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {

        [HttpGet]
        [Route("/greetings")]
        public IActionResult Greet()
        {
            //webapi actions has to to return HttpStatus Code and data
            return Ok("Hello and Welcome to WebAPI Development world"); 
        }

        [HttpGet]
        [Route("/greetings/{guestName}")]
        public IActionResult Greet(string guestName)
        {
            return Ok("Hello " + guestName);
        }
        [HttpGet]
        [Route("add/{num1}/{num2}")]
        public IActionResult AddNumbers(int num1, int num2)
        {
            var add = num1 + num2;
            return Ok("Addition is " + add);
        }

        [HttpGet]
        [Route("/techlist")]
        public IActionResult Technologies()
        {
            string[] techList = new string[5];
            techList[0] = ".Net";
            techList[1] = "MVC";
            techList[2] = "Angular";
            techList[3] = "WEBAPI";
            techList[4] = "SQL Server";

            return Ok(techList);
        }

        [HttpGet]
        [Route("/aboutproject")]
        public IActionResult ProjectInfo()
        {
            var info = new
            {
                projectID = 101,
                projectName = "ShoppingAPP",
                developerName = "Nikhil Shah",
                teamSize = 20,
                isInProduction = false
            };
            return Ok(info);

        }

    }
}









