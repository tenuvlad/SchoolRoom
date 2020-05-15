using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public ICollection<UserClassroomGrade> UserClassroomGrade { get; set; }
    }
}
