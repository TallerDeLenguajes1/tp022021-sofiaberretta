using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrabajoPractico2.Models;
using NLog;

namespace TrabajoPractico2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger _logger;

        public HomeController(ILogger<HomeController> logger, Logger log)
        {
            _logger = log;
            _logger.Info("NLog injected into HomeController");
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
