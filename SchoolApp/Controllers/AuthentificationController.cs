using System;
using Servicies.Users.Dto;
using Servicies.Users;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentificationService _repo;
        private readonly IConfiguration _config;

        public AuthentificationController(IAuthentificationService repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request

            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            userForRegisterDto.FirstName = userForRegisterDto.FirstName.ToLower();
            userForRegisterDto.LastName = userForRegisterDto.LastName.ToLower();
            userForRegisterDto.Email = userForRegisterDto.Email.ToLower();
            userForRegisterDto.Type = userForRegisterDto.Type.ToLower();
            userForRegisterDto.TaughtSubjects = userForRegisterDto.TaughtSubjects.ToLower();
            userForRegisterDto.EnrolledSubjects = userForRegisterDto.EnrolledSubjects.ToLower();

            if (_repo.UserExists(userForRegisterDto.UserName))
                return BadRequest("Username already exist!");
            if (_repo.EmailExists(userForRegisterDto.Email))
                return BadRequest("This email adress already exist!");
            if ( _repo.PhoneExists(userForRegisterDto.PhoneNumber))
                return BadRequest("This phone number already exist!");

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                DateOfBirth = userForRegisterDto.DateOfBitrh,
                Email = userForRegisterDto.Email,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Type = userForRegisterDto.Type,
                TaughtSubjects = userForRegisterDto.TaughtSubjects,
                EnrolledSubjects = userForRegisterDto.EnrolledSubjects
            };

            var createdUser = _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
