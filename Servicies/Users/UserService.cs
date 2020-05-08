using AutoMapper;
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
        public readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public UserService(SchoolContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
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
        public UserForDetailed GetUserDetailed(int id)
        {
            var userToReturn = _mapper.Map<UserForDetailed>(GetById(id));
            return userToReturn;
        }

        public List<UserForList> GetUserList()
        {
            var users = GetAll();
            var usersToReturn = _mapper.Map<List<UserForList>>(users);

            return usersToReturn;
        }

        public void GetUserUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
