namespace CoursesAPI.Models;

public class CourseSyllabusModel
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int ModuleID { get; set; }
    public CourseModel Course { get; set; }
    public ModuleModel Module { get; set; }
}
