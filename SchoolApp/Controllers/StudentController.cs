using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.Courses;
using Servicies.Students;
using Servicies.Students.Dto;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_studentService.StudentList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_studentService.StudentDetail(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateCoursesDropDownList();
            return View();
        }
        private void PopulateCoursesDropDownList(object selectedCourses = null)
        {
            ViewBag.CourseId = new SelectList(_courseService.CourseList(), "Id", "Title", selectedCourses);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(StudentDto newStudent)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            PopulateCoursesDropDownList(newStudent.CourseId);
            _studentService.CreateStudent(newStudent);
            return View(newStudent);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateCoursesDropDownList();
            return View(_studentService.StudentDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditStudent(StudentDto student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            PopulateCoursesDropDownList(student.CourseId);
            _studentService.StudentEdit(student);
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_studentService.StudentDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.StudentDelete(id);
            return RedirectToAction("List");
        }
    }
}
