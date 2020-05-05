using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UserClassroomSubjectGrade
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

    }
}
