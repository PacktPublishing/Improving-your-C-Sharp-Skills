using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(string name = default(string))
        {
            ViewData["Message"] = "Your application description page." + name;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
