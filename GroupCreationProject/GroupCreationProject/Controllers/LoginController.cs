using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;


namespace GroupCreationProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Login();

            return View();
        }

        public void Login()
        {
            try
            {
                HttpClient c = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new { username = "Sean", password = "bar" }), System.Text.Encoding.UTF8, "application/json");
                var result = c.PostAsync("https://localhost:7235/Login/auth",  content).Result;

                if (result.IsSuccessStatusCode)
                {
                    var definition = new { username = "", type = "" };
                    var values = JsonConvert.DeserializeAnonymousType( result.Content.ReadAsStringAsync().Result, definition);

                    Response.Cookies.Append("type", values.type);
                }

            }
            catch
            {

            }
        }
    }
}
