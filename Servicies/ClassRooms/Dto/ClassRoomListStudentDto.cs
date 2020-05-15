using Servicies.Grades.Dto;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.ClassRooms.Dto
{
    public class ClassRoomListStudentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<UserDto> UsersList { get; set; }
    }
}
