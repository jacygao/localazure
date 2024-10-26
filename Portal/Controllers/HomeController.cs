using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using Portal.Services.CosmosDb;
using Portal.Constants;
using System.Diagnostics;
using Microsoft.Azure.Cosmos;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICosmosDbServiceProvider _cosmosDbService;

        public HomeController(
            ILogger<HomeController> logger, 
            ICosmosDbServiceProvider cosmosDbService)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // Map Operation to Status
            Dictionary<string, string> operations = new()
            {
                { "Create Database", "Unhealthy" },
                { "Create Container", "Unhealthy" },
                { "Create Item", "Unhealthy" },
                { "Upsert Item", "Unhealthy" },
                { "Replace Item", "Unhealthy" },
                { "Delete Item", "Unhealthy" }
            };

            List<HealthViewModel> operations = new();
            List<CosmosDbException> cosmosDbExceptions = new();

            try
            {
                _ = await _cosmosDbService.CreateDatabaseAsync(CosmosDbConstants.DatabaseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                operations.Add(new HealthViewModel { Service = "Cosmos DB", Operation = "Create Database", Status = "Unhealthy" });
            }

            try
            {
                _ = await _cosmosDbService.CreateContainerAsync(CosmosDbConstants.DatabaseId);
                _ = await _cosmosDbService.CreateContainerAsync(CosmosDbConstants.DatabaseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                operations.Add(new HealthViewModel { Service = "Cosmos DB", Operation = "Create Container", Status = "Unhealthy" });
            }

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
