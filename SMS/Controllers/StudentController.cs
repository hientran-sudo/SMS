using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext context { get; set; }

        public StudentController(StudentContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var students = context.Students.OrderBy(s => s.StudentId).ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student s)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(s);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var s = context.Students.Find(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(s);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var s = context.Students.Find(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(Student s)
        {
            context.Students.Remove(s);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


