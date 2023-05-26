using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Drawing;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Verfiy(Employee log)
        {
            
            if (true)
            {
                
                return View("AddPatient");
            }
            else
            {
                return View("Error");
            }



        }


      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}