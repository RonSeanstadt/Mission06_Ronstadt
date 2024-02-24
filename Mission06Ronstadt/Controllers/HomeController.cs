using Microsoft.AspNetCore.Mvc;
using Mission06Ronstadt.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Mission06Ronstadt.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext _context;
        public HomeController(MovieApplicationContext temp) // Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Share()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View("Share", new Movie());
        }

        [HttpPost]
        public IActionResult Share(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Adds record to the database
                _context.SaveChanges();

                return View("Submitted", response);
            }
            else // Invalid Data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Collection()
        {
            // Linq
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View("Share", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Share");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }
    }
}
