namespace CoursesAPI.Models;

public class RegistrationModel
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid IDE { get; set; }
    public CourseModel Course { get; set; }
    public StudentModel Student { get; set; }
    public ICollection<StudentProgressModel> StudentProgress { get; set; }
}
