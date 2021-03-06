﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Servicies.Students.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public int Age
        {
            get { return (DateTime.Today - DateOfBirth).Days / 365; }
        }
        [Display(Name = "Average score")]
        public double ScoreAverage { get; set; }
        public int CourseId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public IEnumerable<Grade> GradesList { get; set; }
        public IEnumerable<Course> CoursesList { get; set; }
        public IEnumerable<Enrollment> Enrollment { get; set; }
        public IEnumerable<StudentScore> StudentScore { get; set; }
    }
}
