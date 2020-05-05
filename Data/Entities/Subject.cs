using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name of subject cannot be longer than 50 characters.")]
        [Column("NameOfSubject")]
        [Display(Name = "Name Of Subject")]
        public string NameOfSubject { get; set; }
        [Required]
        public string YearEnrolledSubjects { get; set; }

        public ICollection<UserClassroomSubjectGrade> UserClassroomSubjectGrade { get; set; }
    }
}
