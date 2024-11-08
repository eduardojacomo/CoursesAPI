using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IStudentsRepositories
{
    Task<List<StudentDTO>> GetStudents();
    Task<StudentModel> GetByID(int id);
    Task<StudentDTO> GetStudentByID(int id);
    Task<StudentModel> SetStudent(StudentModel student);
    Task<StudentModel> UpdateStudent(StudentModel student, int id);
    Task<bool> Delete(int id);
}
