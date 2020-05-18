using Servicies.Grades.Dto;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.ClassRooms.Dto
{
    public class ClassRoomDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GradeId { get; set; }
        public string NameClass { get; set; }
        public int NumberOfStudents { get; set; }

    }
}
