using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicies.OfficeAssignments;
using Servicies.OfficeAssignments.Dto;
using Servicies.Teachers;

namespace SchoolApp.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly IOfficeAssignmentService _officeAssignmentService;
        private readonly ITeacherService _teacherService;

        public OfficeAssignmentController(IOfficeAssignmentService officeAssignmentService, ITeacherService teacherService)
        {
            _officeAssignmentService = officeAssignmentService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_officeAssignmentService.OfficeDetail(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopulateTeachersDropDownList();
            return View();
        }
        private void PopulateTeachersDropDownList(object selectedTeachers = null)
        {
            ViewBag.TeacherId = new SelectList(_teacherService.TeacherList(), "Id", "FullName", selectedTeachers);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(OfficeAssignmentsDto newOffice)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _officeAssignmentService.AddNewOffice(newOffice);
            PopulateTeachersDropDownList(newOffice.TeacherId);
            return View(newOffice);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PopulateTeachersDropDownList();
            return View(_officeAssignmentService.OfficeDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditOffice(OfficeAssignmentsDto office)
        {
            _officeAssignmentService.EditOffice(office);
            PopulateTeachersDropDownList(office.TeacherId);
            return View(office);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_officeAssignmentService.OfficeDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteOffice(int id)
        {
            _officeAssignmentService.DeleteOffice(id);
            return RedirectToAction("Detail");
        }
    }
}
