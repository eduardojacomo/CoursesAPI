using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface ICourseRepositories
{
    Task<List<CourseModel>> GetCourses();
    Task<CourseModel> GetByID(int id);
    Task<CourseModel> SetCourse(CourseModel course);
    Task<CourseModel> UpdateCourse(CourseModel course, int id);
    Task<bool> Delete(int id);
    Task<CourseDTO> GetCourseWithModulesAndClasses(int courseID);
    Task<List<SimpleCourseDTO>> GetCoursesByCategory(int categoryID);
}
