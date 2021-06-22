using ManagerFPTs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerFPTs.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Courses
        public ActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }
        public ActionResult Details(int id)
        {
            var course = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (course == null) return HttpNotFound();
            return View(course);

        }
        public ActionResult Delete(int id)
        {
            var course = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (course == null) return HttpNotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description
            };

            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (course == null) return HttpNotFound();
            return View(course);
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);
            if (courseInDb == null) return HttpNotFound();

            courseInDb.Name = course.Name;
            courseInDb.Description = course.Description;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}