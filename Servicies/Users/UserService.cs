using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicies.Users
{
    public class UserService : Repository<User>, IUserService
    {
        public readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public UserService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserDto> GetTeacherList()
        {
            var users = GetAll().Where(u => u.Type == "Teacher");
            var usersToReturn = _mapper.Map<List<UserDto>>(users);

            return usersToReturn;
        }
        public IEnumerable<UserDto> GetStudentList()
        {
            var users = _context.Users.Include(user => user.UserClassroomGrade).ThenInclude(grade => grade.Grade).ToList().Where(u => u.Type == "Student");
            var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersToReturn;
        }
        public UserDto DetailUser(int id)
        {
            var userDetail = GetById(id);
            var users = _context.Users.Include(user => user.UserClassroomGrade).ThenInclude(classRoom => classRoom.ClassRoom).ToList();
            var userToReturn = _mapper.Map<UserDto>(userDetail);

            return userToReturn;
        }


    }
}
