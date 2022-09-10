using GroupCreationProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GroupCreationProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private static List<StudentModelTemp> students = new List<StudentModelTemp>() {
            new StudentModelTemp() {
                Id=1,
                Name="Barbra-Ann",
                GroupId=4,
                Preferences="A group with few students",
                Background=StudentModelTemp.Backgrounds.Design,
                Interest=StudentModelTemp.Interests.Research,
                capability=StudentModelTemp.Capabilities.Frontend

            },
            new StudentModelTemp() {
                Id=2,
                Name="Rachel",
                GroupId=4,
                Preferences="I want a HD(85%)",
                Background=StudentModelTemp.Backgrounds.Design,
                Interest=StudentModelTemp.Interests.Management,
                capability=StudentModelTemp.Capabilities.Servers
            },
            new StudentModelTemp() {
                Id=3,
                Name="Angela",
                GroupId=3,
                Background=StudentModelTemp.Backgrounds.Programming,
                Interest=StudentModelTemp.Interests.UserExperience,
                capability=StudentModelTemp.Capabilities.Routing
            },
        };

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
