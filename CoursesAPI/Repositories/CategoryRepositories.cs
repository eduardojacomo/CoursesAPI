using CoursesAPI.Data;
using CoursesAPI.DTOs;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class CategoryRepositories : ICategoryRepositories
{
    private readonly AppDbContext _dBContext;
    public CategoryRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<CategoryDTO>> GetCategory()
    {
        return await _dBContext.Category
            .AsNoTracking()
            .Select(c => new CategoryDTO
            {
                ID = c.ID,
                Title = c.Title
            })
            .ToListAsync();
    }

    public async Task<CategoryModel> GetByID(int id)
    {
        return await _dBContext.Set<CategoryModel>().FindAsync(id);
    }

    public async Task<CategoryDTO> GetCategoryByID(int id)
    {
        var category = await _dBContext.Category
            .AsNoTracking()
            .Select(c => new CategoryDTO
            {
                ID = c.ID,
                Title = c.Title
            })
            .FirstOrDefaultAsync();
        if (category == null)
        {
            throw new Exception($"Category Id: {id} not found");
        }

        return category;
    }


    public async Task<CategoryModel> SetCategory(CategoryModel category)
    {
        try
        {
            await _dBContext.Category.AddAsync(category);
            await _dBContext.SaveChangesAsync();
            return category;

        }catch (Exception ex)
        {
            throw new Exception($"Category not created");
        }

    }

    public async Task<CategoryModel> UpdateCategory(CategoryModel category, int id)
    {
        CategoryModel categorybyID = await GetByID(id);

        if (categorybyID == null)
        {
            throw new Exception($"Category Id: {id} not found");
        }
        categorybyID.ID = categorybyID.ID;
        categorybyID.Title = category.Title;
        
        try
        {
            _dBContext.Category.Update(categorybyID);
            await _dBContext.SaveChangesAsync();

            return categorybyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Category Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        CategoryModel categorybyID = await GetByID(id);

        if (categorybyID == null)
        {
            throw new Exception($"Category Id: {id} not found");
        }

        try
        {
            _dBContext.Category.Remove(categorybyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Category Id: {id} not deleted");
        }
    }

}
