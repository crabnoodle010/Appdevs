using ManagerFPTs.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerFPTs.Controllers
{
    public class TrainerIfsController : Controller
    {
        private ApplicationDbContext _context;
        public TrainerIfsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: TrainerIfs
        public ActionResult Index()
        {
            var trainerIfs = _context.UserIfs.OfType<TrainerIf>().ToList();
            return View(trainerIfs);
        }
    }
}