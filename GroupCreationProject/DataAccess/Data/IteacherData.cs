using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface ITeacherData
    {

        public Task<teacherModel?> loginTeacher(string email, string password);


    }
}
