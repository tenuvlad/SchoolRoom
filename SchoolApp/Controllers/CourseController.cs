using Microsoft.AspNetCore.Mvc;
using Servicies.Courses;
using Servicies.Courses.Dto;

namespace SchoolApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _repo;

        public CourseController(ICourseService repo)
        {
            _repo = repo;
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
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(CourseDto newCourse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.CreateNewCourse(newCourse);
            return View(newCourse);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.CourseDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditCourse(CourseDto classRoom)
        {
            _repo.EditCourse(classRoom);
            return View(classRoom);
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
