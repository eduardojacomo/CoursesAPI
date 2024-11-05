namespace CoursesAPI.DTOs;

public class SimpleCourseDTO
{
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryID { get; set; }
        public int InstructorID { get; set; }
}
