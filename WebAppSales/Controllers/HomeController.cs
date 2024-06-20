using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppSales.Models;
using WebAppSales.Models.ViewModels;

namespace WebAppSales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewData["Message"] = "Salles Web MVC App C# ";
            ViewData["email"] = "nicolemello6002@gmail.com";

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
