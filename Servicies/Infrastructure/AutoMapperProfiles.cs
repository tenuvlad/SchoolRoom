using AutoMapper;
using Data.Entities;
using Servicies.ClassRooms.Dto;
using Servicies.Grades.Dto;
using Servicies.Users.Dto;
using System.Linq;

namespace Servicies.Infrastructure
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserDto>().ForMember(u => u.Score, opt => opt.MapFrom(s => s.UserClassroomGrade.Select(x => x.Grade).Count()))
                                       .ForMember(c => c.ClassRoomLists, opt => opt.MapFrom(s => s.UserClassroomGrade.Select(x => x.ClassRoom)));

            CreateMap<ClassRoomDto, ClassRoom>();
            CreateMap<ClassRoom, ClassRoomDto>().ForMember(c => c.NumberOfStudents, opt => opt.MapFrom(s => s.UserClassroomGrade.Select(x => x.User).Count()));
            CreateMap<ClassRoom, ClassRoomListStudentDto>().ForMember(c => c.UsersList, opt => opt.MapFrom(s => s.UserClassroomGrade.Select(x => x.User)));

            CreateMap<Grade, GradeDto>();
            CreateMap<GradeDto, Grade>();
        }
    }
}