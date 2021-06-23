using ManagerFPTs.UniqueAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerFPTs.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        [Unique(ErrorMessage = "Department Name already exist !!")]
        public string Name { get; set; }
    }
}