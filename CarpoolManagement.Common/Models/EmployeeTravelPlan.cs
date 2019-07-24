using System.ComponentModel.DataAnnotations;

namespace CarpoolManagement.Common.Models
{
    public class EmployeeTravelPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public int TravelPlanId { get; set; }
        public virtual TravelPlan TravelPlan { get; set; }
    }
}
