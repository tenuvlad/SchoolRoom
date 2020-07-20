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
        private readonly IDepartmentService _departmentService;
        private readonly ITeacherService _teacherService;

        public DepartmentController(IDepartmentService departmentService, ITeacherService teacherService)
        {
            _departmentService = departmentService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_departmentService.DepartmentList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_departmentService.DepartmentDetails(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateTeachersDropDownList();
            return View();
        }
        private void PopulateTeachersDropDownList(object selectedTeachers = null)
        {
            ViewBag.InstructorId = new SelectList(_teacherService.TeacherList(), "Id", "FullName", selectedTeachers);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(DepartmentDto newDepartment)
        {
            if (_departmentService.DepartmentNameExist(newDepartment.Name))
            {
                ModelState.AddModelError("Name", "This department already exist");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            _departmentService.CreateDepartment(newDepartment);
            PopulateTeachersDropDownList(newDepartment.InstructorId);
            return View(newDepartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateTeachersDropDownList();
            return View(_departmentService.DepartmentDetailForEdit(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditCourse(DepartmentDto department)
        {
            if (_departmentService.DepartmentNameExist(department.Name))
            {
                ModelState.AddModelError("Name", "This department already exist");
            }

            _departmentService.EditDepartment(department);
            PopulateTeachersDropDownList(department.InstructorId);
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_departmentService.DepartmentDetailForEdit(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCourse(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("List");
        }
    }
}
