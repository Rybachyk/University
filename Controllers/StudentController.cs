using Microsoft.AspNetCore.Mvc;
using University._DataAccess;
using University.Models.DataBaseModels;
using System.Linq;
using System;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;

        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            var students = _context.Students.ToList();
            ViewBag.Groups = _context.Groups.ToList();
            return View(students);
        }

        public IActionResult Details(Guid id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Student", "Home");
        }

        public IActionResult EditStudent(Guid id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Groups = _context.Groups.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Student", "Home");
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Student", "Home");
        }

        public IActionResult DetailsStudent(Guid id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var group = _context.Groups.FirstOrDefault(g => g.Id == student.GroupId);
            student.Group = group;
            return View(student);
        }


    }
}
