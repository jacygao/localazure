using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.Diagnostics;

namespace Portal.Controllers
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
            var operations = new List<HealthViewModel>
            {
                new HealthViewModel { Service = "Cosmos DB", Operation = "Create Database", Status = "Success" },
                new HealthViewModel { Service = "Cosmos DB", Operation = "Create Container", Status = "Failed" },
                new HealthViewModel { Service = "Cosmos DB", Operation = "Add Item", Status = "Success" },
                new HealthViewModel { Service = "Cosmos DB", Operation = "Update Item", Status = "Success" },
                new HealthViewModel { Service = "Cosmos DB", Operation = "Delete Item", Status = "Failed" }
            };

            return View(operations);
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
