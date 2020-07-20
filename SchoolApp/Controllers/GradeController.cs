using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.Grades;
using Servicies.Grades.Dto;
using Servicies.Students;

namespace SchoolApp.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IStudentService _studentService;
        public GradeController(IStudentService studentService, IGradeService gradeService)
        {
            _studentService = studentService;
            _gradeService = gradeService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_gradeService.GradeList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_gradeService.GradeDetail(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateStudentsDropDownList();
            return View();
        }
        private void PopulateStudentsDropDownList(object selectedStudents = null)
        {
            ViewBag.StudentId = new SelectList(_studentService.StudentList(), "Id", "FullName", selectedStudents);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(GradeDto newGrade)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            PopulateStudentsDropDownList(newGrade.StudentId);
            _gradeService.CreateGrade(newGrade);
            return View(newGrade);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateStudentsDropDownList();
            return View(_gradeService.GradeDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditGrade(GradeDto grade)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            PopulateStudentsDropDownList(grade.StudentId);
            _gradeService.GradeEdit(grade);
            return View(grade);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_gradeService.GradeDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteGrade(int id)
        {
            _gradeService.GradeDelete(id);
            return RedirectToAction("List");
        }
    }
}
