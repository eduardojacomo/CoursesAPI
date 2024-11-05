namespace CoursesAPI.DTOs;

public class CourseDTO
{
    public int CourseID { get; set; }
    public string CourseTitle { get; set; }
    public string CourseDescription { get; set; }
    public string CategoryTitle { get; set; }
    //public string InstructorName { get; set; }
    public List<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();
    public InstructorDTO Instructor { get; set; }
}

public class ModuleDTO
{
    public int ModuleID { get; set; }
    public string ModuleTitle { get; set; }
    public string ModuleDescription { get; set; }
    public List<ClassDTO> Classes { get; set; } = new List<ClassDTO>();
}

public class ClassDTO
{
    public string ClassTitle { get; set; }
    public string ClassDescription { get; set; }
}


public class InstructorDTO
{
    public int InstructorID { get; set; }
    public string InstructorName { get; set; }
    public string InstructorEmail { get; set; }
    public string InstructorPhone { get; set; }
}