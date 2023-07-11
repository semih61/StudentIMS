using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Models.Models;

namespace StudentIMS.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyFirstRazorPage()
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