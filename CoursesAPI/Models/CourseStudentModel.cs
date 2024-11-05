namespace CoursesAPI.Models;

public class CourseStudentModel
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
}
