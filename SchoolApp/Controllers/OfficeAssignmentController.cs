using Microsoft.AspNetCore.Mvc;
using Servicies.OfficeAssignments;
using Servicies.OfficeAssignments.Dto;

namespace SchoolApp.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly IOfficeAssignmentService _repo;

        public OfficeAssignmentController(IOfficeAssignmentService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_repo.OfficeDetail(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(OfficeAssignmentsDto newOffice)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _repo.AddNewOffice(newOffice);
            return View(newOffice);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_repo.OfficeDetail(id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditOffice(OfficeAssignmentsDto office)
        {
            _repo.EditOffice(office);
            return View(office);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_repo.OfficeDetail(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteOffice(int id)
        {
            _repo.DeleteOffice(id);
            return RedirectToAction("Detail");
        }
    }
}
