
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
        [HttpGet("userlist")]
        public IActionResult UserList()
        {
            return View(_repo.GetUserList());
        }
    }
}