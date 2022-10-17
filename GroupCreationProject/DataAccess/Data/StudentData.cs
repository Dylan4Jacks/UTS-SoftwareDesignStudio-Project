using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class StudentData : IStudentData
{
    private readonly ISqlDataAccess _db;

    public StudentData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<StudentModel>> GetStudents() =>
        _db.LoadData<StudentModel, dynamic>("dbo.spStudent_GetAll", new { });

    public async Task<StudentModel?> GetStudent(int id)
    {
        var results = await _db.LoadData<StudentModel, dynamic>(
            "dbo.spStudent_Get",
            new { StudentId = id });
        return results.FirstOrDefault();
    }

    public async Task<StudentModel?> AuthenticateStudent(string email, string password)
    {
        var results = await _db.LoadData<StudentModel, dynamic>(
            "dbo.spStudent_Auth_Get",
            new { Email = email, Password = password });
        return results.FirstOrDefault();
    }

    public Task InsertStudent(StudentModel student) =>
        _db.SaveData("dbo.spStudent_Insert", new {
            student.FirstName,
            student.LastName,
            student.Email,
            student.Password,
            student.GroupId
        });

    public Task UpdateStudent(StudentModel student) =>
        _db.SaveData("dbo.spStudent_Update", student);

    public Task DeleteStudent(int id) =>
        _db.SaveData("dbo.spStudent_Delete", new { StudentId = id });
}
