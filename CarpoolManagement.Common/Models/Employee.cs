using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarpoolManagement.Common.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDriver { get; set; }

        //[Required]
        public virtual ICollection<EmployeeTravelPlan> EmployeeTravelPlans { get; set; }
    }
}
