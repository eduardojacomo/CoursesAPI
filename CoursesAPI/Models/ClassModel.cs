﻿namespace CoursesAPI.Models;

public class ClassModel
{
    //public int ID { get; set; }
    //public string Title { get; set; }
    //public string ClassDescription { get; set; }
    public int ID { get; set; }
    public string Title { get; set; }
    public string ClassDescription { get; set; }
    public int ModuleID { get; set; }

    // Navigation property
    public ModuleModel Module { get; set; }
}