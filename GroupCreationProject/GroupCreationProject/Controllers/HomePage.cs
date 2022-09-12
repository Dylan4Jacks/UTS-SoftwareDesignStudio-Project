using Microsoft.AspNetCore.Mvc;

namespace GroupCreationProject.Controllers
{
    public class HomePage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
