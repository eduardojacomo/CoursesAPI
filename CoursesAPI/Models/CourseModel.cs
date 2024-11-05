namespace CoursesAPI.Models;

public class CourseModel
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryID { get; set; }
    public string Thumbnail { get; set; }

    public int InstructorID { get; set; }
    public CategoryModel Category { get; set; }
    public InstructorsModel Instructor { get; set; }
    public ICollection<CourseSyllabusModel> CourseSyllabi { get; set; }
}
