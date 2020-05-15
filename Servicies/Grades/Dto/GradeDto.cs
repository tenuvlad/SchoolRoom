using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Grades.Dto
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassRoomId { get; set; }
        public int Score { get; set; }
    }
}
