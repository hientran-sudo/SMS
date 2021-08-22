using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class InstructorController : Controller
    {
        private StudentContext context { get; set; }

        public InstructorController(StudentContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var instructors = context.Instructors.OrderBy(i=>i.InstructorId).ToList();
            return View(instructors);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor i)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Add(i);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(i);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var i = context.Instructors.Find(id);
            return View(i);
        }
        [HttpPost]
        public IActionResult Edit(Instructor i)
        {
            if (ModelState.IsValid)
            {
                context.Instructors.Update(i);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(i);
            }
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var i = context.Instructors.Find(id);
            return View(i);
        }
        [HttpPost]
        public IActionResult Delete (Instructor i)
        {
            context.Instructors.Remove(i);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
