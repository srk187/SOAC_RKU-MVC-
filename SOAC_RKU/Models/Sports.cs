using SOAC_RKU.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOAC_RKU.Models
{
    public class Sports
    {
        [Key]
        public string? Enrollment_id { get; set; }
        public string? Sport_Name { get; set; }
        public string? Mentor_name { get; set; }
        public string? Fees { get; set; }
    }
}
