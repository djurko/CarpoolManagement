using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarpoolManagement.Common.Models
{
    public class Carpool
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CarType { get; set; }

        [Required]
        public string Color { get; set; }
        
        [Required]
        [MaxLength(9)]
        [Index("IX_Plates", IsUnique = true)]
        [RegularExpression("[a-zA-Z]{2} \\d{3}-[a-zA-Z]{2}", ErrorMessage = "Wrong plates format. Example: ZG 456-RO")]
        public string Plates { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        public virtual ICollection<TravelPlan> TravelPlans { get; set; }
    }
}
