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
public class InstructorsController : ControllerBase
{
    private readonly IInstructorsRepositories service;

    public InstructorsController(IInstructorsRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetInstructors")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<InstructorsController>>> GetInstructors()
    {
        List<InstructorsModel> instructors = await service.GetInstructors();
        return Ok(instructors);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<InstructorsController>> GetByID(int id)
    {
        InstructorsModel instructors = await service.GetByID(id);
        return Ok(instructors);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<InstructorsModel>> SetInstructor([FromBody] InstructorsModel instructorsModel)
    {
        InstructorsModel instructors = await service.SetInstructor(instructorsModel);

        return Ok(instructors);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<InstructorsModel>> UpdateInstructor([FromBody] InstructorsModel instructorsModel, int id)
    {
        instructorsModel.ID = id;

        InstructorsModel instructors = await service.UpdateInstructor(instructorsModel, id);

        return Ok(instructors);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<InstructorsModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
