using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Servicies.Teachers;
using Servicies.Teachers.Dto;
using System.Net.Http;
using System.Threading.Tasks;

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
            if (_teacherService.FirstNameExists(newTeacher.FirstName))
            {
                ModelState.AddModelError("FirstName", "This name already exist");
            }
            if (_teacherService.LastNameExists(newTeacher.LastName))
            {
                ModelState.AddModelError("LastName", "This name already exist");
            }
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
            if (_teacherService.FirstNameExists(teacher.FirstName))
            {
                ModelState.AddModelError("FirstName", "This name already exist");
            }
            if (_teacherService.LastNameExists(teacher.LastName))
            {
                ModelState.AddModelError("LastName", "This name already exist");
            }

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
