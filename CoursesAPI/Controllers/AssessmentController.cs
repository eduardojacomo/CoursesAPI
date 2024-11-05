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
public class AssessmentController : ControllerBase
{
    private readonly IAssessmentRepositories service;

    public AssessmentController(IAssessmentRepositories service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetAssessments")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<List<AssessmentController>>> GetAssessments()
    {
        List<AssessmentModel> assessments = await service.GetAssessments();
        return Ok(assessments);
    }

    [HttpGet("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<AssessmentController>> GetByID(int id)
    {
        AssessmentModel assessments = await service.GetByID(id);
        return Ok(assessments);
    }

    [HttpPost]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<AssessmentModel>> SetAssessment([FromBody] AssessmentModel assessmentModel)
    {
        AssessmentModel assessment = await service.SetAssessment(assessmentModel);

        return Ok(assessment);
    }

    [HttpPut("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<AssessmentModel>> UpdateAssessment([FromBody] AssessmentModel assessmentModel, int id)
    {
        assessmentModel.ID = id;

        AssessmentModel assessment = await service.UpdateAssessment(assessmentModel, id);

        return Ok(assessment);
    }


    [HttpDelete("{id}")]
    [ProducesDefaultResponseTypeAttribute()]
    public async Task<ActionResult<AssessmentModel>> Delete(int id)
    {

        bool apagado = await service.Delete(id);

        return Ok(apagado);


    }
}
