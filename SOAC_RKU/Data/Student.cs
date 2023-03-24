

using System.ComponentModel.DataAnnotations;

namespace SOAC_RKU.Data
{
    public class Student
    {
        [Key] public string? Enrollment_Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required] public string? Contact { get; set; }
        [Required] public int Age { get; set; }

        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

        [Required][StringLength(50)]
        public string? City { get; set; }

        [Required]
        public string? Department { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string? Gender { get; set; } 

    }
}
