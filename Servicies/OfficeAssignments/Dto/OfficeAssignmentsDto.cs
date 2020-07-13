using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Servicies.OfficeAssignments.Dto
{
    public class OfficeAssignmentsDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
    }
}
