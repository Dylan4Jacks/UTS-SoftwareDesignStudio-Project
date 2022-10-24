using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroupCreationProject.Controllers
{
    [Route("[controller]")]
    public class GroupFormationController : Controller
    {
        private readonly ILogger<GroupFormationController> _logger;

        public GroupFormationController(ILogger<GroupFormationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}

// Get all students in a class (all the students in the database) --> (Use stored procedure to get all students)
// Calculate appropriate size of the groups based on the number of students (e.g more then 3 groups or no more then 5 students per group)
// Create the structures of the groups (get groups from DB then add other attributes) --> GroupCapacity
// Implement the diversity algoritm to form the groups
// Push the groups to the database (Use stored procedure)