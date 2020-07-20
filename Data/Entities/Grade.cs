using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        public double Score { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime DateOfTheGrade { get; set; }
        public IEnumerable<StudentScore> StudentScore { get; set; }
    }
}
