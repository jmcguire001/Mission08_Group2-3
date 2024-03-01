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
            // Linq query to get all categories
            ViewBag.Categories = _repo.Categories.ToList();

            return View(new Models.Task());
        }

        [HttpPost]
        public IActionResult Add(Models.Task response)
        {
            // Check validations
            if (ModelState.IsValid)
            {
                // Add the new record; this action comes from ITasksRepository and EFTasksRepository
                _repo.AddTask(response);

                return View("Confirmation", response);
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

            // Separate queries for each quadrant
            var tasksQuadrant1 = _repo.Tasks.Where(task => task.Quadrant == 1 && task.Completed == false).OrderBy(x => x.TaskName).ToList();
            var tasksQuadrant2 = _repo.Tasks.Where(task => task.Quadrant == 2 && task.Completed == false).OrderBy(x => x.TaskName).ToList();
            var tasksQuadrant3 = _repo.Tasks.Where(task => task.Quadrant == 3 && task.Completed == false).OrderBy(x => x.TaskName).ToList();
            var tasksQuadrant4 = _repo.Tasks.Where(task => task.Quadrant == 4 && task.Completed == false).OrderBy(x => x.TaskName).ToList();

            // Pass the queries to their respective views
            ViewBag.TasksQuadrant1 = tasksQuadrant1;
            ViewBag.TasksQuadrant2 = tasksQuadrant2;
            ViewBag.TasksQuadrant3 = tasksQuadrant3;
            ViewBag.TasksQuadrant4 = tasksQuadrant4;

            return View();
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