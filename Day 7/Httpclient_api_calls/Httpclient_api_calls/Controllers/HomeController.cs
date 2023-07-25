using Httpclient_api_calls.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Httpclient_api_calls.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowPostDetails()
        {
            PostDetails pObj = new PostDetails(); //should use DI here
            ViewBag.post = pObj.GetPostDataFromJSONPlaceHolder();
            return View();
        }

        public IActionResult Index()
        {
            return View();
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
}