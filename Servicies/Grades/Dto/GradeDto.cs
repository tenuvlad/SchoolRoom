using Data.Entities;
using Servicies.Students.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Servicies.Grades.Dto
{
    public class GradeDto
    {
        public int Id { get; set; }
        [Required]
        public double Score { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime DateOfTheGrade { get; set; }
        [Display(Name = "Students")]
        public int StudentId { get; set; }
        [Display(Name = "Students")]
        public IEnumerable<Student> StudentsList { get; set; }
        [Display(Name = "Students")]
        public IEnumerable<StudentScore> StudentScore { get; set; }
    }
}
