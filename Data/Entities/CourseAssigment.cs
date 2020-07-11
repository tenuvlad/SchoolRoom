using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class CourseAssignment 
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
