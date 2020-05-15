using Servicies.ClassRooms.Dto;
using Servicies.Grades.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Users.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int ClassRoomId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBitrh { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public IEnumerable<GradeDto> Score { get; set; }
        public IEnumerable<ClassRoomDto> ClassRoomLists { get; set; }
    }
}
