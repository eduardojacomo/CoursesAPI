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
public class StudentController : ControllerBase
{
    private readonly IStudentsRepositories service;

    public StudentController(IStudentsRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetStudents")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<StudentDTO>>> GetStudents()
    {
        List<StudentDTO> students = await service.GetStudents();
        return Ok(students);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentDTO>> GetStudentByID(int id)
    {
        StudentDTO students = await service.GetStudentByID(id);
        return Ok(students);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentModel>> SetStudent([FromBody] StudentModel studentModel)
    {
        StudentModel student = await service.SetStudent(studentModel);

        return Ok(student);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentModel>> UpdateStudent([FromBody] StudentModel studentModel, int id)
    {
        studentModel.ID = id;

        StudentModel student = await service.UpdateStudent(studentModel, id);

        return Ok(student);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<StudentModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
