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
        User GetUserDetailed(int id);
        List<UserForList> GetUserList();
        void GetUserUpdate();
    }
}
