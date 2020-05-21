using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassRoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}