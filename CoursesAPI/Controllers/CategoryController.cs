using CoursesAPI.Models;
using CoursesAPI.Repositories;
using CoursesAPI.Repositories.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CoursesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepositories service;

    public CategoryController(ICategoryRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetCategory")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<CategoryController>>> GetCategory()
    {
        List<CategoryModel> category = await service.GetCategory();
        return Ok(category);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CategoryController>> GetByID(int id)
    {
        CategoryModel category = await service.GetByID(id);
        return Ok(category);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CategoryModel>> SetCategory([FromBody] CategoryModel categoryModel)
    {
        CategoryModel category = await service.SetCategory(categoryModel);

        return Ok(category);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CategoryModel>> UpdateCategory([FromBody] CategoryModel categoryModel, int id)
    {
        categoryModel.ID = id;

        CategoryModel category = await service.UpdateCategory(categoryModel, id);

        return Ok(category);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CategoryModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
