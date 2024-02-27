using Microsoft.AspNetCore.Mvc;
using Mission08_Group2_3.Models;
using System.Diagnostics;

namespace Mission08_Group2_3.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            ViewBag.Tasks = _repo.TempTask.FirstOrDefault(x => x.TaskId == "Criteria Here");

            return View();
        }
    }
}
