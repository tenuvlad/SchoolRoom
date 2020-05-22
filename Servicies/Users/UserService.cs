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

        public void AddNewUser(UserCreateDto user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var userInclude = _context.ClassRooms.Include(a => a.UserClassroomGrade).Where(b => b.Id == user.ClassRoomId);
            var userReturn = _mapper.Map<User>(user);
            Add(userReturn);
            Commit();
        }

        public void DeleteUser(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var user = GetById(id);
            var userMap = _mapper.Map<User>(user);
            Delete(userMap);
            Commit();
        }

        public void EditUser(UserDto user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var userInclude = _context.ClassRooms.Include(a => a.UserClassroomGrade).Where(b => b.Id == user.ClassRoomId);
            var userUpdate = GetById(user.Id);
            if (userUpdate != null)
            {
                userUpdate.Id = user.Id;
                userUpdate.FirstName = user.FirstName;
                userUpdate.LastName = user.LastName;
                userUpdate.DateOfBirth = user.DateOfBitrh;
                userUpdate.City = user.City;
                userUpdate.Country = user.Country;
                userUpdate.PhoneNumber = user.PhoneNumber;
                userUpdate.Type = user.Type;
            }
            var userReturn = _mapper.Map<User>(userUpdate);
            Update(userReturn);
        }

        public IEnumerable<UserDto> GetUsersList()
        {
            var users = Query().OrderBy(x => x.FirstName).ToList();
            var usersList = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersList;
        }

    }
}
