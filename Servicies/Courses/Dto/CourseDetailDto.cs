using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Servicies.Courses.Dto
{
    public class CourseDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        [DisplayName("Number of students")]
        public int NumberOfStudents { get; set; }
    }
}
