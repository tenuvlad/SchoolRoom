using Servicies.ClassRooms.Dto;
using Servicies.Users.Dto;
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
        public IEnumerable<ClassRoomDto> ClassesGrade { get; set; }
        public IEnumerable<UserDto> UsersGrade { get; set; }
    }
}
