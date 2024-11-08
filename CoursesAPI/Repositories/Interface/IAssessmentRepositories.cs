using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IAssessmentRepositories
{
    Task<List<AssessmentDTO>> GetAssessments();
    Task<AssessmentModel> GetByID(int id);
    Task<AssessmentDTO> GetAssessmentsByID(int id);
    Task<AssessmentModel> SetAssessment(AssessmentModel assessment);
    Task<AssessmentModel> UpdateAssessment(AssessmentModel assessment, int id);
    Task<bool> Delete(int id);
}
