using Data;
using Data.Entities;
using Servicies.ClassRooms.Dto;
using System.Collections.Generic;

namespace Servicies.ClassRooms
{
    public interface IClassRoomService : IRepository<ClassRoom>
    {
        ClassRoomListStudentDto GetClassDetaile(int id);
        IEnumerable<ClassRoomDto> GetClassRoomList();
        ClassRoomDto AddNewClass(ClassRoomDto classRoom);
    }
}
