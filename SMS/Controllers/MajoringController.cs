using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class MajoringController : Controller
    {
        private StudentContext context { get; set; }

        public MajoringController(StudentContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            ViewBag.Students = context.Students.OrderBy(s => s.Name).ToList();
            ViewBag.Majors = context.Majors.OrderBy(m => m.Title).ToList();
            
            mymodel.Majorings = context.Majorings.OrderBy(ma => ma.StudentId).ToList();
            mymodel.Majors = context.Majors.OrderBy(m => m.MajorId).ToList();
            mymodel.Students = context.Students.OrderBy(s => s.StudentId).ToList();
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Students = context.Students.ToList();
            ViewBag.Majors = context.Majors.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Majoring m)
        {
            if (ModelState.IsValid)
            {
                context.Majorings.Add(m);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Students = context.Students.ToList();
                ViewBag.Majors = context.Majors.ToList();
                return View(m);
            }
        }
        
    }
}
