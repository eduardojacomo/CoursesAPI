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
public class ModuleController : ControllerBase
{
    private readonly IModuleRepositories service;

    public ModuleController(IModuleRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetModules")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<ModuleController>>> GetModules()
    {
        List<ModuleModel> module = await service.GetModules();
        return Ok(module);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ModuleController>> GetByID(int id)
    {
        ModuleModel module = await service.GetByID(id);
        return Ok(module);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ModuleModel>> SetModule([FromBody] ModuleModel moduleModel)
    {
        ModuleModel module = await service.SetModule(moduleModel);

        return Ok(module);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ModuleModel>> UpdateModule([FromBody] ModuleModel moduleModel, int id)
    {
        moduleModel.ID = id;

        ModuleModel module = await service.UpdateModule(moduleModel, id);

        return Ok(module);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<ModuleModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
