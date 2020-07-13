using Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicies.Departments.Dto
{
    public class DepartmentDetailDto
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
        [Display(Name = "Teacher")]
        public int AdministratorId { get; set; }
        public Teacher Administrator { get; set; }
    }
}
