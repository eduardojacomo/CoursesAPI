namespace CoursesAPI.Models;

public class ModuleModel
{
    //public int ID { get; set; }
    //public string Title { get; set; }
    //public string ModuleDescription { get; set; }
    //public string ModuleLevel { get; set; }
    public int ID { get; set; }
    public string Title { get; set; }
    public string ModuleDescription { get; set; }
    public string ModuleLevel { get; set; }

    // Navigation properties
    public ICollection<CourseSyllabusModel> CourseSyllabi { get; set; }
    public ICollection<ClassModel> Classes { get; set; }
}
