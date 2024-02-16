using Microsoft.AspNetCore.Mvc;
using Mission06Ronstadt.Models;
using System.Diagnostics;

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

        public IActionResult Share()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Share(Application response)
        {
            _context.Applications.Add(response); // Adds record to the database
            _context.SaveChanges();

            return View("Submitted", response);
        }
    }
}
