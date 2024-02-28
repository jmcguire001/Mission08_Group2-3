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
            // This is temporary; updated this to actually show stuff later
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
                _repo.AddTask(response);

                return View("Confirm", response); // WE NEED A CONFIRMATION PAGE
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList(); // Have to pass the view bag if it's not valid
                // THERE WILL BE AN ERROR WITH CATEGORIES, STILL FIGURING THIS OUT

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
            Mission08_Group2_3.Models.Task edit = _repo.Tasks.Single(x => x.TaskId == id); // This is a LINQ query that will return a single movie from the database
            ViewBag.Categories = _repo.Categories.ToList();

            return View("Add", edit);
        }

        [HttpPost]
        public IActionResult Edit(Mission08_Group2_3.Models.Task update) // TASK WILL BE A PROBLEM, SO SPECIFY IT'S MISSION08_GROUP2_3.MODELS.TASK
        {
            // Check validations for updating
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(update); // NEED TO CREATE A METHOD IN THE REPO FOR UPDATING STUFF

                return RedirectToAction("QuadrantView"); // Redirects to the Collection view
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
            // Delete the proper record
            _repo.DeleteTasks(remove); // NEED TO ADD A METHOD TO REMOVE TASKS

            // Redirect to the Collection view after deletion
            return RedirectToAction("QuadrantView");
        }
    }
}
