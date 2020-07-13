﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Servicies.Departments.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public ICollection<Course> Courses { get; set; }
        public Teacher Teacher { get; set; }
    }
}
