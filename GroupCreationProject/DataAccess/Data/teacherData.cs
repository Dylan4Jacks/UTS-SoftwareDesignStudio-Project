using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class TeacherData : ITeacherData
    {
        private readonly ISqlDataAccess _db;
        
        public TeacherData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<teacherModel?> loginTeacher(string email, string password)
        {

            var results = await _db.LoadData<teacherModel, dynamic>(
            "dbo.spteacher_auth",
            new { email = email, password = password});
            return results.FirstOrDefault();

        }
    }
}
