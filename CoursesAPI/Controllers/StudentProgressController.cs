using CoursesAPI.DTOs;
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
public class StudentProgressController : ControllerBase
{
    private readonly IStudentProgressRepositories service;

    public StudentProgressController(IStudentProgressRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetCourses/{registrationIDE}")]
    [ProducesDefaultResponseTypeAttribute()]

    public async Task<ActionResult<List<StudentProgressDTO>>> GetStudentProgress(Guid registrationIDE)
    {
        var studentProgress = await service.GetStudentProgress(registrationIDE);
        return Ok(studentProgress);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentProgressModel>> SetStudentProgress([FromBody] StudentProgressModel studentprogressModel)
    {
        StudentProgressModel studentprogress = await service.SetStudentProgress(studentprogressModel);

        return Ok(studentprogress);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentProgressModel>> UpdateStudentProgress([FromBody] StudentProgressModel studentprogressModel, int id)
    {
        studentprogressModel.ID = id;

        StudentProgressModel studentprogress = await service.UpdateStudentProgress(studentprogressModel, id);

        return Ok(studentprogress);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentProgressModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }

}
