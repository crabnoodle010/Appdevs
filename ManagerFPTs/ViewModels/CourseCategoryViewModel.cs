using ManagerFPTs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerFPTs.ViewModels
{
    public class CourseCategoryViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}