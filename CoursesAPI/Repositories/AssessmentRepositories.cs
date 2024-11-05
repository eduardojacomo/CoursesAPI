using CoursesAPI.Data;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class AssessmentRepositories : IAssessmentRepositories
{
    private readonly AppDbContext _dBContext;
    public AssessmentRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<AssessmentModel>> GetAssessments()
    {
        return await _dBContext.Assessment.AsNoTracking().ToListAsync();
    }

    public async Task<AssessmentModel> GetByID(int id)
    {
        return await _dBContext.Set<AssessmentModel>().FindAsync(id);
    }


    public async Task<AssessmentModel> SetAssessment(AssessmentModel assessment)
    {
        try
        {
            await _dBContext.Assessment.AddAsync(assessment);
            await _dBContext.SaveChangesAsync();
            return assessment;

        }catch (Exception ex)
        {
            throw new Exception($"Assessment not created");
        }

    }

    public async Task<AssessmentModel> UpdateAssessment(AssessmentModel assessment, int id)
    {
        AssessmentModel assessmentbyID = await GetByID(id);

        if (assessmentbyID == null)
        {
            throw new Exception($"Assessment Id: {id} not found");
        }
        assessmentbyID.ID = assessmentbyID.ID;
        assessmentbyID.StudentID = assessment.StudentID;
        assessmentbyID.ModuleID = assessment.ModuleID;
        assessmentbyID.Comments = assessment.Comments;
        assessmentbyID.Score = assessment.Score;

        try
        {
            _dBContext.Assessment.Update(assessmentbyID);
            await _dBContext.SaveChangesAsync();

            return assessmentbyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Assessment Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        AssessmentModel assessmentbyID = await GetByID(id);

        if (assessmentbyID == null)
        {
            throw new Exception($"Assessment Id: {id} not found");
        }

        try
        {
            _dBContext.Assessment.Remove(assessmentbyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Assessment Id: {id} not deleted");
        }
    }

}
