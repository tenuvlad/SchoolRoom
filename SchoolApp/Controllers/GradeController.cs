using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Servicies.Grades;
using Servicies.Grades.Dto;

namespace SchoolApp.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _repo;

        public GradeController(IGradeService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GradeList()
        {
            return View(_repo.GetGradeList());
        }

        [HttpGet("grade/create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GradeDto grade)
        {
            _repo.AddNewGrade(grade);
            return View(grade);
        }
    }
}