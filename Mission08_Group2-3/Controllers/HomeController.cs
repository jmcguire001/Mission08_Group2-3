using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Group2_3.Models;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

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

        public IActionResult Index()
        {
            // This is temporary; update this to actually show stuff later
            ViewBag.Tasks = _repo.Tasks.FirstOrDefault(x => x.TaskId.Equals("Criteria Here"));

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Linq query to get all tasks
            ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Mission08_Group2_3.Models.Task response)
        {
            // Check validations
            if (ModelState.IsValid)
            {
                // Add the new record; this action comes from ITasksRepository and EFTasksRepository
                _repo.AddTask(response);

                return View("Confirm", response);
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList(); // Have to pass the view bag if it's not valid

                return View(response);
            }
        }

        public IActionResult QuadrantView()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            // This is a LINQ query that will return a list of movies from the Movie database
            var task = _repo.Tasks
                .OrderBy(x => x.TaskName).
                ToList();

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id) // Parameter name needs to match the asp-action, which is id
        {
            // Have to use Mission08_Group2_3.Models.Task to ensure program isn't confused
            Mission08_Group2_3.Models.Task edit = _repo.Tasks.Single(x => x.TaskId == id); // This is a LINQ query that will return a single task from the database
            ViewBag.Categories = _repo.Categories.ToList();

            return View("Add", edit);
        }

        [HttpPost]
        public IActionResult Edit(Mission08_Group2_3.Models.Task update)
        {
            // Check validations for updating
            if (ModelState.IsValid)
            {
                // Update the proper record; this action comes from ITasksRepository and EFTasksRepository
                _repo.UpdateTask(update);

                return RedirectToAction("QuadrantView"); // Redirects to the QuadrantView view
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList(); // Have to pass the view bag if it's not valid

                return View("Add", update);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Make sure we get the proper record to send to confirmation
            var delete = _repo.Tasks.Single(x => x.TaskId == id);

            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(Mission08_Group2_3.Models.Task remove)
        {
            // Delete the proper record; this action comes from ITasksRepository and EFTasksRepository
            _repo.DeleteTask(remove);

            // Redirect to the Collection view after deletion
            return RedirectToAction("QuadrantView");
        }
    }
}
