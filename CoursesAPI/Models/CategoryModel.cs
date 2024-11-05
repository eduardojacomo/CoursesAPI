namespace CoursesAPI.Models;

public class CategoryModel
{
    //public int ID { get; set; }
    //public string Title { get; set; }
    public int ID { get; set; }
    public string Title { get; set; }

    
    public ICollection<CourseModel> Courses { get; set; }
}
