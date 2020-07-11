using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class OfficeAssignment
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
    }
}
