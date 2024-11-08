﻿namespace CoursesAPI.Models;

public class AssessmentModel
{
    public int ID { get; set; }
    public int ModuleID { get; set; }
    public int StudentID { get; set; }
    public Double Score { get; set; }
    public string Comments { get; set; }
    public ModuleModel Module { get; set; }
    public StudentModel Student { get; set; }
}
