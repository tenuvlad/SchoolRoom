using Data.Entities;
using Servicies.Grades.Dto;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Servicies.ClassRooms.Dto
{
    public class ClassRoomDto
    {
        public int Id { get; set; }
        public int[] UserId { get; set; }
        public int[] GradeId { get; set; }
        [DisplayName("Name of class")]
        public string NameClass { get; set; }
        [DisplayName("Number of students")]
        public int NumberOfStudents { get; set; }
        public IEnumerable<UserDto> UserForClass { get; set; }
        public IEnumerable<GradeDto> GradeClass { get; set; }
        public IEnumerable<UserClassroomGrade> Users { get; set; }
    }
}
