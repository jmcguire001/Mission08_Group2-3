using Microsoft.AspNetCore.Mvc;
using Mission08_Group2_3.Models;
using System.Diagnostics;

namespace Mission08_Group2_3.Controllers
{
    public class HomeController : Controller
    {
        // Instanciate the repository
        private ITaskRepository _repo;

        // Constructor for scaffolding with repositories
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
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
            // This is temporary; updated this to actually show stuff later
            ViewBag.Tasks = _repo.TempTask.FirstOrDefault(x => x.TaskId == "Criteria Here");

            return View();
        }
    }
}
