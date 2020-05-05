using Data;
using Data.Entities;
using Servicies.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicies.Users
{
    public class UserService : Repository<User>, IUserService
    {
        public readonly Repository<User> _repo;
        public readonly SchoolContext _context;

        public UserService(SchoolContext context,Repository<User> repo) : base(context)
        {
            _context = context;
            _repo = repo;
        }

        public User AddUser(User user)
        {
            Add(user);
            Commit();
            return user;
        }

        public User DeleteUser(User user)
        {
            Delete(user);
            Commit();
            return user;
        }
        public User GetUserDetailed(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public List<UserForList> GetUserList()
        {
            var users = _repo.GetAll();
            var userDtos = new List<UserForList>();
            foreach (var user in users)
            {
                var userDto = new UserForList
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    DateOfBitrh = user.DateOfBirth,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Type = user.Type,
                    EnrolledSubjects = user.EnrolledSubjects,
                    TaughtSubjects = user.TaughtSubjects
                };
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public void GetUserUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
