using Microsoft.AspNetCore.Mvc;
using Servicies.Users;

namespace SchoolApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _repo;

        public UserController(IUserService repo)
        {
            _repo = repo;
        }
        
        [HttpGet("user/teacherall")]
        public IActionResult TeacherList()
        {
            return View(_repo.GetTeacherList());
        }

        [HttpGet("user/studentall")]
        public IActionResult StudentList()
        {
            return View(_repo.GetStudentList());
        }

        [HttpGet("user/detail/{id}")]
        public IActionResult UserDetail(int id)
        {
            return View(_repo.DetailUser(id));
        }
    }
}