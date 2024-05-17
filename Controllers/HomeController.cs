using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using University._DataAccess;
using University.Models;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UniversityContext _context;

        public HomeController(ILogger<HomeController> logger, UniversityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Student()
        {
            var students = _context.Students.ToList();
            ViewBag.Groups = _context.Groups.ToList();
            return View(students);
        }
        public IActionResult Group()
        {
            var groups = _context.Groups.ToList();
            return View(groups);
        }
        public IActionResult Teacher()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}