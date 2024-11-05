namespace CoursesAPI.Models;

public class CourseDetailModel
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Thumbnail { get; set; }
    public int CategoryID { get; set; }
    public string CategoryTitle { get; set; }
    public int ModuleID { get; set; }
    public string ModuleTitle { get; set; }
    public string ModuleDescription { get; set; }
    public string ModuleLevel { get; set; }
    public int ClassID { get; set; }
    public string ClassTitle { get; set; }
    public string ClassDescription { get; set; }


}
