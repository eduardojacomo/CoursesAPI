namespace CoursesAPI.Models;

public class AssessmentModel
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Double Score { get; set; }
    public string Coments { get; set; }
}
