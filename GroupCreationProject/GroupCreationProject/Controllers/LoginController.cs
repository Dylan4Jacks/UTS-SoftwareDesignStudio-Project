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
                HttpClient c = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(new { email = data.Email, password = data.Password }), System.Text.Encoding.UTF8, "application/json");
                string name = "";
                int id = -1; 

                string role;
                if (!data.Email.ToLowerInvariant().Contains("teacher"))
                {
                    role = "student";
                    var Postresult = c.PostAsync("https://localhost:7041/Auth/Student",  content).Result;
                    
                    if(Postresult.IsSuccessStatusCode)
                    {
                        //NOTE USER is Depricated. Check for return type of Student or Teacher
                        var user = JsonConvert.DeserializeObject<StudentModel>(Postresult.Content.ReadAsStringAsync().Result);
                        if(user != null && user.FirstName != null&& user.LastName != null)
                        {
                            name = user.FirstName + " " + user.LastName;
                            id = user.StudentId;

                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, name),
                                new Claim(ClaimTypes.Role, role),
                                new Claim(type: "id", id.ToString())
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                            return RedirectToAction("Student", "User");
                        }
                        else
                        {
                            throw new Exception("Auth Failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Auth Failed");
                    }
                }
                else
                {
                    role = "teacher";
                    var Postresult = c.PostAsync("https://localhost:7041/Auth/Teacher", content).Result;

                    if (Postresult.IsSuccessStatusCode)
                    {
                        var teacher = JsonConvert.DeserializeObject<TeacherModel>(Postresult.Content.ReadAsStringAsync().Result);
                        if(teacher != null && teacher.FirstName != null)
                        {
                            name = teacher.FirstName + " " + teacher.LastName;
                            id = teacher.TeacherId;

                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, name),
                                new Claim(ClaimTypes.Role, role),
                                new Claim(type: "id", id.ToString())
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                            return RedirectToAction("Teacher", "User");
                        }
                        else
                        {
                            throw new Exception("User Data Corrupted");
                        }
                    }
                    else
                    {
                        throw new Exception("Auth Failed");
                    }
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
