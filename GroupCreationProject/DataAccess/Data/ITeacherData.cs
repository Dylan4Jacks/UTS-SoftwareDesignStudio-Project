using DataAccess.Models;

namespace DataAccess.Data;
public interface ITeacherData
{
    Task<TeacherModel?> AuthenticateTeacher(string email, string password);
    Task DeleteTeacher(int id);
    Task<TeacherModel?> GetTeacher(int id);
    Task<IEnumerable<TeacherModel>> GetTeachers();
    Task InsertTeacher(TeacherModel teacher);
    Task UpdateTeacher(TeacherModel teacher);
}