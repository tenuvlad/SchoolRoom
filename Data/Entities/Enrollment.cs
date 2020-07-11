using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
