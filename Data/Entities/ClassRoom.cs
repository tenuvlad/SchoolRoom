using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class ClassRoom
    {
        public int Id { get; set; }
        [Required]
        public string NameClass { get; set; }
        public ICollection<UserClassroomGrade> UserClassroomGrade { get; set; }
    }
}
