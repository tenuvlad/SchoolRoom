using Microsoft.AspNetCore.Mvc;
using Servicies.ClassRooms;
using Servicies.ClassRooms.Dto;
using System.Linq;

namespace SchoolApp.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomService _repo;

        public ClassRoomController(IClassRoomService repo)
        {
            _repo = repo;
        }
        [HttpGet("class/classlist")]
        public IActionResult ClassList()
        {
            return View(_repo.GetClassRoomList());
        }

        [HttpGet("class/detail/{id}")]
        public IActionResult StudentsFromAClass(int id)
        {
            return View(_repo.GetClassDetaile(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("class/create"), ActionName("Create")]
        public IActionResult CreateClass(ClassRoomDto classRoom)
        {
            return View(_repo.AddNewClass(classRoom));
        }
    }
}