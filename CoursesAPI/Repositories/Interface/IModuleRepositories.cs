using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IModuleRepositories
{
    Task<List<ModuleModel>> GetModules();
    Task<ModuleModel> GetByID(int id);
    Task<ModuleModel> SetModule(ModuleModel module);
    Task<ModuleModel> UpdateModule(ModuleModel module, int id);
    Task<bool> Delete(int id);
}
