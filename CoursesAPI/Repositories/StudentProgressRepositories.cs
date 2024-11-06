using CoursesAPI.Data;
using CoursesAPI.DTOs;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class StudentProgressRepositories : IStudentProgressRepositories
{
    private readonly AppDbContext _dBContext;
    public StudentProgressRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<StudentProgressDTO>> GetStudentProgress(Guid registrationIDE)
    {
        return await _dBContext.StudentProgress
            .Where(c => c.RegistrationIDE == registrationIDE)
           .AsNoTracking()
           .Select(c => new StudentProgressDTO
           {
               ID = c.ID,
               StartDate = c.StartDate,
               CompletionDate = c.CompletionDate,
               RegistrationIDE = c.RegistrationIDE,
               ModuleID = c.ModuleID,
               ClassID = c.ClassID
           })
           .ToListAsync();
    }

    public async Task<StudentProgressModel> GetStudentProgressByID(int id)
    {
        return await _dBContext.Set<StudentProgressModel>().FindAsync(id);
    }


    public async Task<StudentProgressModel> SetStudentProgress(StudentProgressModel studentprogress)
    {
        try
        {
            await _dBContext.StudentProgress.AddAsync(studentprogress);
            await _dBContext.SaveChangesAsync();
            return studentprogress;

        }catch (Exception ex)
        {
            throw new Exception($"StudentProgress not created");
        }

    }

    public async Task<StudentProgressModel> UpdateStudentProgress(StudentProgressModel studentprogress, int id)
    {
        StudentProgressModel studentprogressbyID = await GetStudentProgressByID(id);

        if (studentprogressbyID == null)
        {
            throw new Exception($"Student Id: {id} not found");
        }
        studentprogressbyID.StartDate = studentprogress.StartDate;
        studentprogressbyID.CompletionDate = studentprogress.CompletionDate;
        studentprogressbyID.RegistrationIDE= studentprogress.RegistrationIDE;
        studentprogressbyID.ModuleID = studentprogress.ModuleID;
        studentprogressbyID.ClassID = studentprogress.ClassID;


        try
        {
            _dBContext.StudentProgress.Update(studentprogressbyID);
            await _dBContext.SaveChangesAsync();

            return studentprogressbyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"StudentProgress Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        StudentProgressModel studentprogressbyID = await GetStudentProgressByID(id);

        if (studentprogressbyID == null)
        {
            throw new Exception($"StudentProgress Id: {id} not found");
        }

        try
        {
            _dBContext.StudentProgress.Remove(studentprogressbyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"StudentProgress Id: {id} not deleted");
        }
    }

}
