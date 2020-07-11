using Microsoft.AspNetCore.Mvc;
using Servicies.Students;
using Servicies.Students.Dto;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _repo;

        public StudentController(IStudentService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_repo.StudentList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_repo.StudentDetail(id));
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

            _repo.CreateStudent(newStudent);
            return View(newStudent);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.StudentDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditStudent(StudentDto student)
        {
            _repo.StudentEdit(student);
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_repo.StudentDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(int id)
        {
            _repo.StudentDelete(id);
            return RedirectToAction("List");
        }
    }
}
