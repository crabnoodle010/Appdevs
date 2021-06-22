using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerFPTs.Models
{
    public class TraineeIf
    {
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}