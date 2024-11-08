﻿using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IInstructorsRepositories
{
    Task<List<InstructorDTO>> GetInstructors();
    Task<InstructorsModel> GetByID(int id);
    Task<InstructorDTO> GetInstructorByID(int id);
    Task<InstructorsModel> SetInstructor(InstructorsModel instructors);
    Task<InstructorsModel> UpdateInstructor(InstructorsModel instructors, int id);
    Task<bool> Delete(int id);
}
