using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.Courses;
using Servicies.Courses.Dto;
using Servicies.Departments;
using Servicies.Departments.Dto;
using Servicies.Students;
using System.Linq;

namespace SchoolApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _repo;
        private readonly IDepartmentService _department;
        private readonly IStudentService _student;

        public CourseController(ICourseService repo, IDepartmentService department, IStudentService student)
        {
            _repo = repo;
            _department = department;
            _student = student;
        }

        [HttpGet("course/courseList")]
        public IActionResult CourseList()
        {
            return View(_repo.CourseList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_repo.CourseDetail(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }
        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _department.GetAll()
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery, "Id", "Name", selectedDepartment);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(CourseDto newCourse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repo.CreateNewCourse(newCourse);
            PopulateDepartmentsDropDownList(newCourse.DepartmentId);
            return View(newCourse);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.CourseDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditCourse(CourseDto course)
        {
            _repo.EditCourse(course);
            PopulateDepartmentsDropDownList(course.DepartmentId);
            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_repo.CourseDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCourse(int id)
        {
            _repo.DeleteCourse(id);
            return RedirectToAction("CourseList");
        }
    }
}
