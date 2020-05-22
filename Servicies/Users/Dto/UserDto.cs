using Data.Entities;
using Servicies.ClassRooms.Dto;
using Servicies.Grades.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Servicies.Users.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int ClassRoomId { get; set; }
        public string UserName { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Date of birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBitrh { get; set; }
        public int Age
        {
            get { return (DateTime.Today - DateOfBitrh).Days / 365; }
        }
        public string City { get; set; }
        public string Country { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public int Score { get; set; }
        public IEnumerable<ClassRoomDto> ClassRoomList { get; set; }
        public IEnumerable<UserClassroomGrade> ClassRooms { get; set; }
    }
}
