﻿using Data.Entities;
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
        [Range(0, 5)]
        public int Credits { get; set; }
        [DisplayName("Number of students")]
        public int DepartmentId { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }

    }
}
