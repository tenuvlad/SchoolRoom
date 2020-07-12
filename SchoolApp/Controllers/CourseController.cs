using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.Courses;
using Servicies.Courses.Dto;
using Servicies.Departments;
using Servicies.Students;
using Servicies.Teachers;

namespace SchoolApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentService _departmentService;

        public CourseController(ICourseService courseService, IStudentService studentService, ITeacherService teacherService, IDepartmentService departmentService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _teacherService = teacherService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_courseService.CourseList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_courseService.CourseDetail(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            PopulateStudentsDropDownList();
            PopulateTeachersDropDownList();
            return View();
        }
        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            ViewBag.DepartmentId = new SelectList(_departmentService.DepartmentList(), "Id", "Name", selectedDepartment);
        }
        private void PopulateStudentsDropDownList(object selectedStudent = null)
        {
            ViewBag.StudentId = new SelectList(_studentService.StudentList(), "Id", "FullName", selectedStudent);
        }
        private void PopulateTeachersDropDownList(object selectedTeachers = null)
        {
            ViewBag.TeacherId = new SelectList(_teacherService.TeacherList(), "Id", "FullName", selectedTeachers);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(CourseDto newCourse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _courseService.CreateNewCourse(newCourse);
            PopulateDepartmentsDropDownList(newCourse.DepartmentId);
            PopulateStudentsDropDownList(newCourse.StudentId);
            PopulateTeachersDropDownList(newCourse.TeacherId);
            return View(newCourse);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateDepartmentsDropDownList();
            PopulateStudentsDropDownList();
            PopulateTeachersDropDownList();
            return View(_courseService.CourseForEditDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditCourse(CourseDto course)
        {
            _courseService.EditCourse(course);
            PopulateDepartmentsDropDownList(course.DepartmentId);
            PopulateStudentsDropDownList(course.StudentId);
            PopulateTeachersDropDownList(course.TeacherId);
            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_courseService.CourseForEditDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("List");
        }
    }
}
