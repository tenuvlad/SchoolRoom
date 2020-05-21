using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicies.Users;
using Servicies.Users.Dto;

namespace SchoolApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _repo;

        public UserController(IUserService repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public IActionResult TeacherList()
        {
            return View(_repo.GetTeacherList());
        }

        [HttpGet]
        public IActionResult StudentList()
        {
            return View(_repo.GetStudentList());
        }

        [HttpGet]
        public IActionResult UserDetail(int id)
        {
            return View(_repo.DetailUser(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(UserCreateDto user)
        {
            _repo.AddNewUser(user);
            return View(user);
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpDelete,ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteUser(id);
            return View(id);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.DetailUser(id));
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult UserEdit(UserCreateDto user)
        {
            _repo.EditUser(user);
            return View(user);
        }
    }
}