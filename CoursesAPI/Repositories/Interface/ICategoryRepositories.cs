using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface ICategoryRepositories
{
    Task<List<CategoryModel>> GetCategory();
    Task<CategoryModel> GetByID(int id);
    Task<CategoryModel> SetCategory(CategoryModel category);
    Task<CategoryModel> UpdateCategory(CategoryModel category, int id);
    Task<bool> Delete(int id);
}
