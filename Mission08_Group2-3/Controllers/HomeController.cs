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
            ViewBag.Tasks = _repo.TempTask.FirstOrDefault(x => x.TaskId == "Criteria Here");

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
        public IActionResult Add(Task response)
        {
            // Check validations
            if (ModelState.IsValid)
            {
                _repo.Tasks.Add(response);
                _repo.SaveChanges();

                return View("Confirm", response); // WE NEED A CONFIRMATION PAGE
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
            Task edit = _repo.Tasks.Single(x => x.TaskId == id); // This is a LINQ query that will return a single movie from the database
            ViewBag.Categories = _repo.Categories.ToList();

            return View("Add", edit);
        }

        [HttpPost]
        public IActionResult Edit(Task update)
        {
            // Check validations for updating
            if (ModelState.IsValid)
            {
                _repo.Movies.Update(update);
                _repo.SaveChanges();


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
        public IActionResult Delete(Task remove)
        {
            // Delete the proper record
            _repo.Tasks.Remove(remove);
            _repo.SaveChanges();

            // Redirect to the Collection view after deletion
            return RedirectToAction("QuadrantView");
        }
    }
}
