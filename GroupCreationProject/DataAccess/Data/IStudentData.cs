using DataAccess.Models;

namespace DataAccess.Data;
public interface IStudentData
{
    Task DeleteStudent(int id);
    Task<StudentModel?> GetStudent(int id);
    Task<IEnumerable<StudentModel>> GetStudents();
    Task InsertStudent(StudentModel student);
    Task UpdateStudent(StudentModel student);
}