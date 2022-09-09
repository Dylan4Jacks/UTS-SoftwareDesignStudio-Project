using Microsoft.AspNetCore.Mvc;

namespace GroupCreationProject.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
