namespace CoursesAPI.DTOs;

public class CourseDTO
{
    public int CourseID { get; set; }
    public string CourseTitle { get; set; }
    public string CourseDescription { get; set; }
    public string CategoryTitle { get; set; }
    public List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
    public InstructorDTO Instructor { get; set; }
}


