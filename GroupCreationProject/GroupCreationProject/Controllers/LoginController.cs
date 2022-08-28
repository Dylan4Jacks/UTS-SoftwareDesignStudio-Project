using Microsoft.AspNetCore.Mvc;

namespace GroupCreationProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
