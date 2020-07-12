using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.Courses;
using Servicies.Departments;
using Servicies.Departments.Dto;
using Servicies.Teachers;
using System;

namespace SchoolApp.Controllers
{
    public class DepartmentController: Controller
    {
        private readonly IDepartmentService _repo;
        private readonly ITeacherService _teacherService;

        public DepartmentController(IDepartmentService repo, ITeacherService teacherService)
        {
            _repo = repo;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_repo.DepartmentList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_repo.DepartmentDetails(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateTeachersDropDownList();
            return View();
        }
        private void PopulateTeachersDropDownList(object selectedTeachers = null)
        {
            ViewBag.TeacherId = new SelectList(_teacherService.TeacherList(), "Id", "FullName", selectedTeachers);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(DepartmentDto newDepartment)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.CreateDepartment(newDepartment);
            PopulateTeachersDropDownList(newDepartment.TeacherId);
            return View(newDepartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateTeachersDropDownList();
            return View(_repo.DepartmentDetailForEdit(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditCourse(DepartmentDto department)
        {
            _repo.EditDepartment(department);
            PopulateTeachersDropDownList(department.TeacherId);
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_repo.DepartmentDetailForEdit(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCourse(int id)
        {
            _repo.DeleteDepartment(id);
            return RedirectToAction("List");
        }
    }
}
