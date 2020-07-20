using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Servicies.Courses;
using Servicies.Teachers;
using Servicies.Teachers.Dto;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;

        public TeacherController(ITeacherService teacherService, ICourseService courseService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_teacherService.TeacherList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_teacherService.TeacherDetail(id));
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
        public IActionResult CreatePost(TeacherDto newTeacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            PopulateCoursesDropDownList(newTeacher.CourseId);
            _teacherService.CreateTeacher(newTeacher);
            return View(newTeacher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateCoursesDropDownList();
            return View(_teacherService.TeacherDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditTeacher(TeacherDto teacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            PopulateCoursesDropDownList(teacher.CourseId);
            _teacherService.TeacherEdit(teacher);
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_teacherService.TeacherDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteTeacher(int id)
        {
            _teacherService.TeacherDelete(id);
            return RedirectToAction("List");
        }
    }
}
