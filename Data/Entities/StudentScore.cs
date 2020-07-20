using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class StudentScore
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
