namespace CoursesAPI.Models;

public class InstructorsModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ICollection<CourseModel> Courses { get; set; }
}
