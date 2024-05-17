using Microsoft.AspNetCore.Mvc;
using University._DataAccess;
using University.Models.DataBaseModels;
using System.Linq;
using System;

namespace University.Controllers
{
    public class TeacherController : Controller
    {
        private readonly UniversityContext _context;

        public TeacherController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            return RedirectToAction("Teacher", "Home");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("Teacher", "Home");
        }

        public IActionResult EditTeacher(Guid id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public IActionResult EditTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return RedirectToAction("Teacher", "Home");
        }
    }
}
