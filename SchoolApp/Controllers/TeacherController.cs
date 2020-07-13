using Microsoft.AspNetCore.Mvc;
using Servicies.Teachers;
using Servicies.Teachers.Dto;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
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
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(TeacherDto newTeacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _teacherService.CreateTeacher(newTeacher);
            return View(newTeacher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_teacherService.TeacherDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditTeacher(TeacherDto teacher)
        {
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
