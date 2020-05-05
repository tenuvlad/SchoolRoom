using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class ClassRoom
    {
        public int Id { get; set; }
        [Required]
        public int NumberClass { get; set; }
        [Required]
        public string NameClass { get; set; }
        [Required]
        public int NumberOfStudents { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartPromotionClass { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndPromotionClass { get; set; }
        public ICollection<UserClassroomSubjectGrade> UserClassroomSubjectGrade { get; set; }
    }
}
