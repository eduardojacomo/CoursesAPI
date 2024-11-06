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
public class CourseController : ControllerBase
{
    private readonly ICourseRepositories service;

    public CourseController(ICourseRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetCourses")]
    [ProducesDefaultResponseTypeAttribute()]

    public async Task<ActionResult<List<SimpleCourseDTO>>> GetCourses()
    {
        var courses = await service.GetCourses();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]

    public async Task<ActionResult<SimpleCourseDTO>> GetCourseByID(int id)
    {
        var course = await service.GetCourseByID(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CourseModel>> SetCourse([FromBody] CourseModel courseModel)
    {
        CourseModel course = await service.SetCourse(courseModel);

        return Ok(course);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CourseModel>> UpdateCourse([FromBody] CourseModel courseModel, int id)
    {
        courseModel.ID = id;

        CourseModel course = await service.UpdateCourse(courseModel, id);

        return Ok(course);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<CourseModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }

    [HttpGet("CourseDetails/{courseID}")]
    //public async Task<CourseDTO> GetCourseWithModulesAndClasses(int courseId)
    public async Task<IActionResult> GetCourseWithModulesAndClasses(int courseID)
    {
 
        var course = await service.GetCourseWithModulesAndClasses(courseID);
        if (course == null)
        {
            return NotFound($"No courses found for category ID {courseID}");
        }

        return Ok(course);
    }

    [HttpGet("CoursesByCategory/{categoryID}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<CourseModel>>> GetCoursesByCategory(int categoryID)
    {
        var courses = await service.GetCoursesByCategory(categoryID);

        if (courses == null || !courses.Any())
        {
            return NotFound($"No courses found for category ID {categoryID}");
        }

        return Ok(courses);
    }
}
