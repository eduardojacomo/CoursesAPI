using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IClassRepositories
{
    Task<List<ClassDTO>> GetClass();
    Task<ClassModel> GetByID(int id);
    Task<ClassDTO> GetClassByID(int id);
    Task<ClassModel> SetClass(ClassModel _class);
    Task<ClassModel> UpdateClass(ClassModel _class, int id);
    Task<bool> Delete(int id);
}
