using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IModuleRepositories
{
    Task<List<ModulesDTO>> GetModules();
    Task<ModuleModel> GetByID(int id);
    Task<ModulesDTO> GetModuleByID(int id);
    Task<ModuleModel> SetModule(ModuleModel module);
    Task<ModuleModel> UpdateModule(ModuleModel module, int id);
    Task<bool> Delete(int id);
}
