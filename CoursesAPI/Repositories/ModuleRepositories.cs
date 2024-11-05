using CoursesAPI.Data;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class ModuleRepositories: IModuleRepositories
{
    private readonly AppDbContext _dBContext;
    public ModuleRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<ModuleModel>> GetModules()
    {
        return await _dBContext.Module.AsNoTracking().ToListAsync();
    }

    public async Task<ModuleModel> GetByID(int id)
    {
        return await _dBContext.Set<ModuleModel>().FindAsync(id);
    }


    public async Task<ModuleModel> SetModule(ModuleModel module)
    {
        try
        {
            await _dBContext.Module.AddAsync(module);
            await _dBContext.SaveChangesAsync();
            return module;

        }catch (Exception ex)
        {
            throw new Exception($"Module not created");
        }

    }

    public async Task<ModuleModel> UpdateModule(ModuleModel module, int id)
    {
        ModuleModel modulebyID = await GetByID(id);

        if (modulebyID == null)
        {
            throw new Exception($"Student Id: {id} not found");
        }
        modulebyID.ID = modulebyID.ID;
        modulebyID.Title = module.Title;
        modulebyID.ModuleDescription = module.ModuleDescription;
        try
        {
            _dBContext.Module.Update(modulebyID);
            await _dBContext.SaveChangesAsync();

            return modulebyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Module Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        ModuleModel modulebyID = await GetByID(id);

        if (modulebyID == null)
        {
            throw new Exception($"Module Id: {id} not found");
        }

        try
        {
            _dBContext.Module.Remove(modulebyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Module Id: {id} not deleted");
        }
    }

}
