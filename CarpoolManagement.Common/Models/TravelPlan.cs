using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarpoolManagement.Common.Models
{
    public class TravelPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StartLocation { get; set; }

        [Required]
        public string EndLocation { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        //[Required]
        public virtual Carpool Car { get; set; }

        //[Required]
        public virtual ICollection<EmployeeTravelPlan> EmployeeTravelPlans { get; set; }
    }
}
