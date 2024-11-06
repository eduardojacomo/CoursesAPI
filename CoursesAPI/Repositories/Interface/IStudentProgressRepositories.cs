using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IStudentProgressRepositories
{
    Task<List<StudentProgressDTO>> GetStudentProgress(Guid registrationIDE);
    Task<StudentProgressModel> GetStudentProgressByID(int id);
    Task<StudentProgressModel> SetStudentProgress(StudentProgressModel studentprogress);
    Task<StudentProgressModel> UpdateStudentProgress(StudentProgressModel studentprogress, int id);
    Task<bool> Delete(int id);
}
