using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class MajorController : Controller
    {
        private StudentContext context { get; set; }

        public MajorController(StudentContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var majors = context.Majors.OrderBy(m => m.MajorId).ToList();
            return View(majors);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Major m)
        {
            if (ModelState.IsValid)
            {
                context.Majors.Add(m);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var m = context.Majors.Find(id);
            return View(m);
        }
        [HttpPost]
        public IActionResult Delete(Major m)
        {           
            context.Majors.Remove(m);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
