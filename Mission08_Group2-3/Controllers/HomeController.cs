using Microsoft.AspNetCore.Mvc;
using Mission08_Group2_3.Models;
using System.Diagnostics;

namespace Mission08_Group2_3.Controllers
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
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult QuadrantView()
        {
            return View();
        }
    }
}
