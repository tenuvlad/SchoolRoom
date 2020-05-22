using Servicies.Grades.Dto;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Servicies.ClassRooms.Dto
{
    public class ClassRoomDetailDto
    {
        public int Id { get; set; }
        [DisplayName("Name of class")]
        public string NameClass { get; set; }
        public int UserId { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}
