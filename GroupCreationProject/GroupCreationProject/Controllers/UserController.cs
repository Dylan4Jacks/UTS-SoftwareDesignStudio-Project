using GroupCreationProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace GroupCreationProject.Controllers
{
    public class UserController : Controller
    {
        HttpClient c = new HttpClient();
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
            List<StudentModel> students = new List<StudentModel>() { new StudentModel(){ StudentId = 1, FirstName = "Ann", LastName = "Mo", Email = "Ann@Gmail.com", Password = "12345" } };
            return PartialView("_StudentsPartial", students);
        }

        public IActionResult GroupsPartial()
        {
            List<GroupModel> groups = new List<GroupModel>() { new GroupModel() { GroupId = 1, GroupName = "A" } };
            return PartialView("_GroupsPartial", groups);
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
