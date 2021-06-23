using ManagerFPTs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ManagerFPTs.ViewModels;

namespace ManagerFPTs.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Teams
        [HttpGet]
        public ActionResult Index()
        {
            var teams = _context.Departments.ToList();
            return View(teams);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            var newdepartment = new Department
            {
                Name = department.Name
            };

            _context.Departments.Add(newdepartment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Members(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var traineeIfs = _context.DepartmentTrainees
                .Include(d => d.User)
                .Where(d => d.DepartmentId == id)
                .Select(d => d.User);

            ViewBag.DepartmentId = id;

            return View(traineeIfs);
        }
        [HttpGet]
        public ActionResult AddMembers(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (_context.Departments.SingleOrDefault(t => t.Id == id) == null) return HttpNotFound();

            var usersInDb = _context.Users.ToList();

            var usersInD = _context.DepartmentTrainees
                .Include(d => d.User)
                .Where(d => d.DepartmentId == id)
                .Select(d => d.User)
                .ToList();

            var usersToAdd = new List<ApplicationUser>();

            foreach (var user in usersInDb)
            {
                if (!usersInD.Contains(user) &&
                    _userManager.GetRoles(user.Id)[0].Equals("trainee"))
                {
                    usersToAdd.Add(user);
                }
            }

            var viewModel = new DepartmentTraineeViewModel
            {
                DepartmentId = (int)id,
                Users = usersToAdd
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddMembers(DepartmentTrainee model)
        {
            var departmentTrainee = new DepartmentTrainee
            {
                DepartmentId = model.DepartmentId,
                UserId = model.UserId
            };

            _context.DepartmentTrainees.Add(departmentTrainee);
            _context.SaveChanges();

            return RedirectToAction("Members", new { id = model.DepartmentId });
        }
        [HttpGet]
        public ActionResult RemoveMember(int id, string userId)
        {
            var departmentTraineeToRemove = _context.DepartmentTrainees.SingleOrDefault(t => t.DepartmentId == id && t.UserId == userId);

            if (departmentTraineeToRemove == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            _context.DepartmentTrainees.Remove(departmentTraineeToRemove);
            _context.SaveChanges();
            return RedirectToAction("Members", new { id = id });
        }
    }
}