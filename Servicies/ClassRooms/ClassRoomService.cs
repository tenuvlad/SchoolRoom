using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.ClassRooms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicies.ClassRooms
{
    public class ClassRoomService : Repository<ClassRoom>, IClassRoomService
    {
        public readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public ClassRoomService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<ClassRoomDto> GetClassRoomList()
        {
            var classRoom = _context.ClassRooms.Include(x => x.UserClassroomGrade).ThenInclude(y => y.User).ToList();
            var classToReturn = _mapper.Map<IEnumerable<ClassRoomDto>>(classRoom);

            return classToReturn;
        }
        public ClassRoomListStudentDto GetClassDetaile(int id)
        {
            var classRoomDetail = GetById(id);
            var classToReturn = _context.ClassRooms.Include(x => x.UserClassroomGrade).ThenInclude(y => y.User).ToList();
            var studentListFromClassReturn = _mapper.Map<ClassRoomListStudentDto>(classRoomDetail);
            return studentListFromClassReturn;
        }

        public void AddNewClass(ClassRoomDto classRoom)
        {
            if (classRoom == null) throw new ArgumentNullException(nameof(classRoom));
            var classRoomReturn = _mapper.Map<ClassRoom>(classRoom);
            Add(classRoomReturn);
            Commit();
        }

    }
}
