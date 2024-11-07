namespace CoursesAPI.Models;

public class StudentProgressModel
{
    public int ID { get; set; }
    public int ModuleID { get; set; }
    public int ClassID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public Guid RegistrationIDE { get; set; }
    public int RegistrationID { get; set; }
    public RegistrationModel Registration { get; set; }
    public ModuleModel Module { get; set; }
    public ClassModel Class { get; set; }
}
