using Data;
using Data.Entities;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicies.Users
{
    public interface IUserService : IRepository<User>
    {
        void AddNewUser(UserCreateDto user);
        UserDto DetailUser(int id);
        List<UserDto> GetTeacherList();
        IEnumerable<UserDto> GetStudentList();
        void DeleteUser(int id);
        void EditUser(UserCreateDto user);
    }
}
