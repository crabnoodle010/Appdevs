using ManagerFPTs.UniqueAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerFPTs.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Unique(ErrorMessage = "Category already exist !!")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}