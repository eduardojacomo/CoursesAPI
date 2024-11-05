namespace CoursesAPI.Models;

public class RegistrationModel
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public DateTime RegistrationDate { get; set; }
}
