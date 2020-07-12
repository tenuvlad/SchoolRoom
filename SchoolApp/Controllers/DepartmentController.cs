using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.Courses;
using Servicies.Departments;
using Servicies.Departments.Dto;
using System;

namespace SchoolApp.Controllers
{
    public class DepartmentController: Controller
    {
        private readonly IDepartmentService _repo;

        public DepartmentController(IDepartmentService repo)
        {
            _repo = repo;
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
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(DepartmentDto newDepartment)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.CreateDepartment(newDepartment);
            return View(newDepartment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.DepartmentDetailForEdit(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditCourse(DepartmentDto department)
        {
            _repo.EditDepartment(department);
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
