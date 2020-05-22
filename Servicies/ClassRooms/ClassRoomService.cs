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
        public ClassRoomDetailDto ClassDetaile(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var classId = GetById(id);
            var classMap = _context.ClassRooms.Include(x => x.UserClassroomGrade).ThenInclude(y => y.User).ToList();
            var classReturn = _mapper.Map<ClassRoomDetailDto>(classId);

            return classReturn;
        }

        public void AddNewClass(ClassRoomDto classRoom)
        {
            if (classRoom == null) throw new ArgumentNullException(nameof(classRoom));
            var classMap = _context.ClassRooms.Include(x => x.UserClassroomGrade).ThenInclude(y => y.User).ToList();
            var classRoomReturn = _mapper.Map<ClassRoom>(classRoom);
            Add(classRoomReturn);
            Commit();
        }

        public void EditClass(ClassRoomDto classRoom)
        {
            if (classRoom == null) throw new ArgumentNullException(nameof(classRoom));
            var classId = GetById(classRoom.Id);
            if (classId != null)
            {
                classId.Id = classRoom.Id;
                classId.NameClass = classRoom.NameClass;
            }
            var classRoomReturn = _mapper.Map<ClassRoom>(classId);
            Update(classRoomReturn);
        }

        public ClassRoomDto ClassDetailes(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var classId = GetById(id);
            var classReturn = _mapper.Map<ClassRoomDto>(classId);

            return classReturn;
        }
        public AddUserClassDto GetUserClassById(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var classId = GetById(id);
            var classReturn = _mapper.Map<AddUserClassDto>(classId);

            return classReturn;
        }
        public void DeleteClass(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var classroom = GetById(id);
            var classMap = _mapper.Map<ClassRoom>(classroom);
            Delete(classMap);
            Commit();
        }

        public void AddUserClass(AddUserClassDto newUserClass)
        {
            User user = _context.Users
                .Include(x => x.UserClassroomGrade).ThenInclude(y => y.ClassRoom)
                .FirstOrDefault(c => c.Id == newUserClass.UserId);

            if (user == null) throw new ArgumentNullException(nameof(user));

            ClassRoom classroom = _context.ClassRooms
                .FirstOrDefault(c => c.Id == newUserClass.ClassRoomId);

            if (classroom == null) throw new ArgumentNullException(nameof(classroom));

            Grade grade = _context.Grades
                .FirstOrDefault(c => c.Id == newUserClass.GradeId);

            if (grade == null) throw new ArgumentNullException(nameof(grade));

            UserClassroomGrade userClassroomGrade = new UserClassroomGrade
            {
                User = user,
                ClassRoom = classroom,
                Grade = grade
            };

            _context.UserClassroomGrades.Add(userClassroomGrade);
            Commit();

            var classMap = _mapper.Map<ClassRoomDto>(classroom);
        }
    }
}
