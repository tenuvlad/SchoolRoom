using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Servicies.Departments.Dto
{
    public class DepartmentDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        [Display(Name = "Teacher")]
        public string TeacherFullName { get; set; }
    }
}
