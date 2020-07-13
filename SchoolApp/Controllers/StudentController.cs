using Microsoft.AspNetCore.Mvc;
using Servicies.Students;
using Servicies.Students.Dto;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(StudentDto newStudent)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _studentService.CreateStudent(newStudent);
            return View(newStudent);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_studentService.StudentDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditStudent(StudentDto student)
        {
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
