using Microsoft.AspNetCore.Mvc;
using Mission08_Group2_3.Models;
using System.Diagnostics;

namespace Mission08_Group2_3.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult QuadrantView()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
