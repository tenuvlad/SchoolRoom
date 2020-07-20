using Data.Entities;
using Servicies.Departments.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Servicies.Courses.Dto
{
    public class CourseDto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public int CourseNumber { get; set; }
        [Range(0, 5)]
        public int Credits { get; set; }
        [DisplayName("Number of students")]
        public int NumberOfStudents { get; set; }
        public int DepartmentId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        [DisplayName("Departments")]
        public Department Department { get; set; }
        [DisplayName("Students")]
        public IEnumerable<Enrollment> Enrollments { get; set; }
        [DisplayName("Teachers")]
        public IEnumerable<CourseAssignment> CourseAssignments { get; set; }
    }
}
