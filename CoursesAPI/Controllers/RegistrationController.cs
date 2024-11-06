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
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationRepositories service;

    public RegistrationController(IRegistrationRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetStudents")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<RegistrationController>>> GetRegistrations()
    {
        List<RegistrationModel> registration = await service.GetRegistrations();
        return Ok(registration);
    }

    [HttpGet("{ide}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<IActionResult> GetByIDE(Guid ide)
    {

        var registration = await service.GetByIDE(ide);
        if (registration == null)
        {
            return NotFound($"No registration found for IDE {ide}");
        }

        return Ok(registration);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<RegistrationModel>> SetRegistration([FromBody] RegistrationModel registrationModel)
    {
        RegistrationModel registration = await service.SetRegistration(registrationModel);

        return Ok(registration);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<RegistrationModel>> UpdateRegistration([FromBody] RegistrationModel registrationModel, int id)
    {
        registrationModel.ID = id;

        RegistrationModel registration = await service.UpdateRegistration(registrationModel, id);

        return Ok(registration);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<RegistrationModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
