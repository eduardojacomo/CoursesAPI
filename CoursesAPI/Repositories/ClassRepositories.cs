using CoursesAPI.Data;
using CoursesAPI.DTOs;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class ClassRepositories: IClassRepositories
{
    private readonly AppDbContext _dBContext;
    public ClassRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<ClassDTO>> GetClass()
    {
        return await _dBContext.Class
            .AsNoTracking()
            .Select(c => new ClassDTO
            {
                ID = c.ID,
                ClassTitle = c.Title,
                ClassDescription = c.ClassDescription,
                ModuleID = c.ModuleID
            })
            .ToListAsync();
    }

    public async Task<ClassModel> GetByID(int id)
    {
        return await _dBContext.Set<ClassModel>().FindAsync(id);
    }

    public async Task<ClassDTO> GetClassByID(int id)
    {
        var _class = await _dBContext.Class
           .Where(c => c.ID == id)
           .Select(c => new ClassDTO
           {
               ID = c.ID,
               ClassTitle = c.Title,
               ClassDescription = c.ClassDescription,
               ModuleID = c.ModuleID
           })
            .FirstOrDefaultAsync();
        return _class;
    }

    public async Task<ClassModel> SetClass(ClassModel _class)
    {
        try
        {
            await _dBContext.Class.AddAsync(_class);
            await _dBContext.SaveChangesAsync();
            return _class;

        }catch (Exception ex)
        {
            throw new Exception($"Class not created");
        }

    }

    public async Task<ClassModel> UpdateClass(ClassModel _class, int id)
    {
        ClassModel classbyID = await GetByID(id);

        if (classbyID == null)
        {
            throw new Exception($"Student Id: {id} not found");
        }
        classbyID.ID = classbyID.ID;
        classbyID.Title = _class.Title;
        classbyID.ClassDescription = _class.ClassDescription;
        try
        {
            _dBContext.Class.Update(classbyID);
            await _dBContext.SaveChangesAsync();

            return classbyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Class Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        ClassModel classebyID = await GetByID(id);

        if (classebyID == null)
        {
            throw new Exception($"Class Id: {id} not found");
        }

        try
        {
            _dBContext.Class.Remove(classebyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Class Id: {id} not deleted");
        }
    }

}
