using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineInventorySystem.Data;
using OnlineInventorySystem.Models;

namespace OnlineInventorySystem.Controllers
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
            
            return SessionCheck();
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

        private IActionResult SessionCheck()
        {
            string sessionCompanyId = HttpContext.Session.GetString("_CompanyID");
            if (string.IsNullOrEmpty(sessionCompanyId))
            {
                return View("~/Views/Start/Index.cshtml");
            }
            return View("Index");
        }
    }
}
