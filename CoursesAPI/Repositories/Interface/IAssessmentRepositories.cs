using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IAssessmentRepositories
{
    Task<List<AssessmentModel>> GetAssessments();
    Task<AssessmentModel> GetByID(int id);
    Task<AssessmentModel> SetAssessment(AssessmentModel assessment);
    Task<AssessmentModel> UpdateAssessment(AssessmentModel assessment, int id);
    Task<bool> Delete(int id);
}
