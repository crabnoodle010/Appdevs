using ManagerFPTs.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerFPTs.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminsController : Controller
    {
        private ApplicationDbContext _context;
        public AdminsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admins
        public ActionResult Index()
        {
            var adminId = User.Identity.GetUserId();
            var adminIf = _context.UserIfs.OfType<Admin>().SingleOrDefault(a => a.UserId.Equals(adminId));

            if (adminIf == null) return HttpNotFound();


            return View(adminIf);
        }
    }
}