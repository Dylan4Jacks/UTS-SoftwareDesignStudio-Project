using GroupCreationProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GroupCreationProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        public IActionResult Teacher()
        {
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }

        public IActionResult StudentsPartial()
        {
            return PartialView("_StudentsPartial");
        }

        public IActionResult GroupsPartial()
        {
            return PartialView("_GroupsPartial");
        }

        public IActionResult CategoriesPartial()
        {
            return PartialView("_CategoriesPartial");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
