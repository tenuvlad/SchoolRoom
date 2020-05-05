using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Users
{
    public interface IAuthentificationService : IRepository<User>
    {
        User Register(User user, string password);
        User Login(string username, string password);
        bool UserExists(string username);
        bool EmailExists(string email);
        bool PhoneExists(string phone);
    }
}
