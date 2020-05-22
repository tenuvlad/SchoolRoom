using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.ClassRooms.Dto
{
    public class AddUserClassDto
    {
        public int UserId { get; set; }
        public int ClassRoomId { get; set; }
        public int GradeId { get; set; }
    }
}
