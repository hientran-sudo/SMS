using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CourseController : Controller
    {
        private StudentContext context { get; set; }

        public CourseController(StudentContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var courses = context.Courses.OrderBy(c => c.CourseId).ToList();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Course c)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var c = context.Courses.Find(id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Course c)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Update(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var c = context.Courses.Find(id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Delete(Course c)
        {
            context.Courses.Remove(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

