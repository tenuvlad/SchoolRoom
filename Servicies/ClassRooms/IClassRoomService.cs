using Data;
using Data.Entities;
using Servicies.ClassRooms.Dto;
using System.Collections.Generic;

namespace Servicies.ClassRooms
{
    public interface IClassRoomService : IRepository<ClassRoom>
    {
        IEnumerable<ClassRoomDto> GetClassRoomList();
        public ClassRoomDetailDto ClassDetaile(int id);
        void AddNewClass(ClassRoomDto classRoom);
/*        void AddUserToClass(ClassRoomDto classRoom);*/
        void EditClass(ClassRoomDto classRoom);
        ClassRoomDto ClassDetailes(int id);
        ClassRoomDto AddUserClass(AddUserClassDto newUserClass);
        AddUserClassDto GetUserClassById(int id);
    }
}
