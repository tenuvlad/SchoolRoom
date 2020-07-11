using Microsoft.AspNetCore.Mvc;
using Servicies.Teachers;
using Servicies.Teachers.Dto;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _repo;

        public TeacherController(ITeacherService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_repo.TeacherList());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_repo.TeacherDetail(id));
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

            _repo.CreateTeacher(newTeacher);
            return View(newTeacher);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.TeacherDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditTeacher(TeacherDto teacher)
        {
            _repo.TeacherEdit(teacher);
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_repo.TeacherDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteTeacher(int id)
        {
            _repo.TeacherDelete(id);
            return RedirectToAction("List");
        }
    }
}
