using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerFPTs.Models
{
    public class DepartmentTrainee
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}