using Data.Entities;
using Servicies.Departments.Dto;
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
        [DisplayName("Department")]
        public Department Department { get; set; }
        public IEnumerable<Teacher> TeachersList { get; set; }
        public IEnumerable<Student> StudentsList { get; set; }
    }
}
