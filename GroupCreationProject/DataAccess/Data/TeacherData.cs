using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class TeacherData : ITeacherData
{
    private readonly ISqlDataAccess _db;

    public TeacherData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<TeacherModel>> GetTeachers() =>
        _db.LoadData<TeacherModel, dynamic>("dbo.spTeacher_GetAll", new { });

    public async Task<TeacherModel?> GetTeacher(int id)
    {
        var results = await _db.LoadData<TeacherModel, dynamic>(
            "dbo.spTeacher_Get",
            new { TeacherId = id });
        return results.FirstOrDefault();
    }

    public async Task<TeacherModel?> AuthenticateTeacher(string email, string password)
    {
        var results = await _db.LoadData<TeacherModel, dynamic>(
            "dbo.spTeacher_Auth_Get",
            new { Email = email, Password = password });
        return results.FirstOrDefault();
    }

    public Task InsertTeacher(TeacherModel teacher) =>
        _db.SaveData("dbo.spTeacher_Insert", new {
            teacher.FirstName,
            teacher.LastName,
            teacher.Email,
            teacher.Password
        });

    public Task UpdateTeacher(TeacherModel teacher) =>
        _db.SaveData("dbo.spTeacher_Update", teacher);

    public Task DeleteTeacher(int id) =>
        _db.SaveData("dbo.spTeacher_Delete", new { TeacherId = id });
}
