using SOAC_RKU.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOAC_RKU.Models
{
    public class Clubs
    {
        [Key]
        public string? Enrollment_id { get; set; }
        public string? Club_name { get; set; }
        public string? Mentor_name { get; set; }
        public string? Fees { get; set; }
    }
}
