using Microsoft.AspNetCore.Mvc;
using University._DataAccess;
using University.Models.DataBaseModels;
using System.Linq;
using System;

namespace University.Controllers
{
    public class GroupController : Controller
    {
        private readonly UniversityContext _context;

        public GroupController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Group()
        {
            var groups = _context.Groups.ToList();
            return View(groups);
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(group);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditGroup(Guid id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost]
        public IActionResult EditGroup(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
            return RedirectToAction("Group", "Home");
        }
    }
}
