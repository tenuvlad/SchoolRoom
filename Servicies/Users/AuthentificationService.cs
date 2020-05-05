using Data.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Servicies.Users
{
    public class AuthentificationService : Repository<User>,IAuthentificationService
    {
        public readonly SchoolContext _context;
        public AuthentificationService(SchoolContext context) : base(context)
        {
            _context = context;
        }
        public User Login(string username, string password)
        {
            var user =_context.Users.FirstOrDefault(x => x.UserName == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatPasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            Add(user);
            Commit();

            return user;
        }

        private void CreatPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool UserExists(string username)
        {
            if (_context.Users.Any(x => x.UserName == username))
                return true;

            return false;
        }
        public bool EmailExists(string email)
        {
            if (_context.Users.Any(x => x.Email == email))
                return true;

            return false;
        }
        public bool PhoneExists(string phone)
        {
            if (_context.Users.Any(x => x.PhoneNumber == phone))
                return true;

            return false;
        }
    }
}
