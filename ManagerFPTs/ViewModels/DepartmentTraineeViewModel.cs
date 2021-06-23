using ManagerFPTs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerFPTs.ViewModels
{
    public class DepartmentTraineeViewModel
    {
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}