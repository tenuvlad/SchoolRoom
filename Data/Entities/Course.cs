using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name = "Number")]
        public int CourseNumber { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Range(0, 5)]
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Enrollment> Enrollment { get; set; }
        public IEnumerable<CourseAssignment> CourseAssignment { get; set; }
    }
}
