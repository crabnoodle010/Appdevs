using ManagerFPTs.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ManagerFPTs.ViewModels;

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
        public ActionResult Index(string searchString)
        {
            var courses = _context.Courses.Include(t => t.Category).ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                courses = courses.Where(t => t.Name.Contains(searchString)).ToList();
            }
            return View(courses);
        }
        public ActionResult Details(int id)
        {
            var course = _context.Courses.Include(t => t.Category).SingleOrDefault(t => t.Id == id);
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
            var viewmodel = new CourseCategoryViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CourseCategoryViewModel()
                {
                    Course = course,
                    Categories = _context.Categories.ToList()
                };
                return View(viewmodel);
            }
            var newCourse = new Course
            {
                Name = course.Name,
                CategoryId = course.CategoryId,
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
            var viewmodel = new CourseCategoryViewModel()
            {
                Course = course,
                Categories = _context.Categories.ToList()
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CourseCategoryViewModel()
                {
                    Course = course,
                    Categories = _context.Categories.ToList()
                };
                return View(viewmodel);
            }
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);
            if (courseInDb == null) return HttpNotFound();

            courseInDb.Name = course.Name;
            courseInDb.CategoryId = course.CategoryId;
            courseInDb.Description = course.Description;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}