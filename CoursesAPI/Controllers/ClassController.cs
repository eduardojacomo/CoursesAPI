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
public class ClassController : ControllerBase
{
    private readonly IClassRepositories service;

    public ClassController(IClassRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetClass")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<ClassController>>> GetClass()
    {
        List<ClassModel> _class = await service.GetClass();
        return Ok(_class);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ClassController>> GetByID(int id)
    {
        ClassModel _class = await service.GetByID(id);
        return Ok(_class);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ClassModel>> SetClass([FromBody] ClassModel classModel)
    {
        ClassModel _class = await service.SetClass(classModel);

        return Ok(_class);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ClassModel>> UpdateClass([FromBody] ClassModel classModel, int id)
    {
        classModel.ID = id;

        ClassModel _class = await service.UpdateClass(classModel, id);

        return Ok(_class);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ClassModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
