using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.ViewModel;
using Servicies.ClassRooms;
using Servicies.ClassRooms.Dto;
using Servicies.Users;
using Servicies.Users.Dto;

namespace SchoolApp.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomService _repo;
        private readonly IUserService _user;

        public ClassRoomController(IClassRoomService repo, IUserService user)
        {
            _repo = repo;
            _user = user;
        }
        [HttpGet]
        public IActionResult ClassList()
        {
            return View(_repo.GetClassRoomList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_repo.ClassDetaile(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(ClassRoomDto newClassRoom)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.AddNewClass(newClassRoom);
            return View(newClassRoom);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.ClassDetailes(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditClass(ClassRoomDto classRoom)
        {
            _repo.EditClass(classRoom);
            return View(classRoom);
        }

        [HttpGet("classroom/AddUserToClass/{id}")]
        public IActionResult AddUserToClass(int id)
        {
            return View(_repo.GetUserClassById(id));
        }

        [HttpPost, ActionName("AddUserToClass")]
        public IActionResult AddUserClass(AddUserClassDto newUserClass)
        {
            _repo.AddUserClass(newUserClass);
            return RedirectToAction("AddUserToClass");
        }
    }
}