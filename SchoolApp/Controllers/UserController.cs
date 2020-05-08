
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Servicies.Users;
using Servicies.Users.Dto;
using System.Collections.Generic;

namespace SchoolApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _repo;

        public UserController(IUserService repo)
        {
            _repo = repo;
        }
        [HttpGet("user/getall")]
        public IActionResult UserList()
        {
            return View(_repo.GetUserList());
        }
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult UserDetailed(int id)
        {
            return View(_repo.GetUserDetailed(id));
        }
    }
}