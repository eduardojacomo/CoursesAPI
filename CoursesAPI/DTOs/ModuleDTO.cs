namespace CoursesAPI.DTOs;

public class ModuleDTO
{
    public int ModuleID { get; set; }
    public string ModuleTitle { get; set; }
    public string ModuleDescription { get; set; }
    public List<ClassDTO> Classes { get; set; } = new List<ClassDTO>();
}
