namespace CoursesAPI.DTOs;

public class RegistrationDTO
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid IDE { get; set; }
}
