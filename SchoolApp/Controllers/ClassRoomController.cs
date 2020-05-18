using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Servicies.ClassRooms;
using Servicies.ClassRooms.Dto;

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
    }
}