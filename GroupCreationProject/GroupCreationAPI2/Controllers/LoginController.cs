using GroupCreationAPI.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroupCreationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {

        }

        [HttpPost]
        [Route("auth")]
        public IActionResult Authenticate(AuthRequestModel request)
        {

            try
            {
                if (request.username == "Sean" && request.password == "bar")
                    return Ok(new { username = "Sean", type = "student" });
                else if (request.username == "Steve" && request.password == "bar")
                    return Ok(new { username = "Steve", type = "teacher" });
                else
                    return NotFound(new { message = "wrong username or password" });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
