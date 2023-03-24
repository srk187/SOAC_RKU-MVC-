
using System.ComponentModel.DataAnnotations;

namespace SOAC_RKU.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Enrollment Id is Required")]
        public string? Enrollment_Id { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is Required")]
        public string? Password { get;set; }
    }
}
