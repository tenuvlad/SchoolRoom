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
        public IActionResult Delete(int id)
        {
            return View(_repo.DetailUser(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteUser(int id)
        {
            _repo.DeleteUser(id);
            return RedirectToAction("StudentList");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.DetailUser(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult UserEdit(UserDto user)
        {
            _repo.EditUser(user);
            return View(user);
        }
    }
}