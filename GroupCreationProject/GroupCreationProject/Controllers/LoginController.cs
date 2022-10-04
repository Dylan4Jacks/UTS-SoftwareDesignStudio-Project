using GroupCreationProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Security.Claims;

namespace GroupCreationProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginRequestData data)
        {
            try
            {
                //HttpClient c = new HttpClient();
                //var content = new StringContent(JsonConvert.SerializeObject(new { username = "Sean", password = "bar" }), System.Text.Encoding.UTF8, "application/json");
                //var result = c.PostAsync("https://localhost:7235/Login/auth",  content).Result;

                string role;
                if (data.Email.Contains("teacher"))
                    role = "teacher";
                else
                    role = "student";


                var result = new
                {
                    success = true,
                    values = new
                    {
                        type = "student",
                        name = "sean"
                    }
                };

                if (true)
                {
                    //var definition = new { username = "", type = "" };
                    //var values = JsonConvert.DeserializeAnonymousType( result.Content.ReadAsStringAsync().Result, definition);

                    //Response.Cookies.Append("type", result.values.type);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, data.Email),
                        new Claim(ClaimTypes.Role, role)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                   // var authProperties = new AuthenticationProperties
                   // {
                   //     AllowRefresh = true,
                   //     ExpiresUtc = DateTimeOffset.UtcNow.AddHours(48),
                   //     IsPersistent = true,
                   //     IssuedUtc = DateTimeOffset.UtcNow,
                   // };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect("~Home/Privacy");
                }
            }
            catch
            {
                return LocalRedirect("~Home/Privacy");
            }
        }
    }
}
