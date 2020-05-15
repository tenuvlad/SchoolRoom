using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UserClassroomGrade
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

    }
}
