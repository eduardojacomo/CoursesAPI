using CoursesAPI.Data;
using CoursesAPI.DTOs;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class InstructorsRepositories: IInstructorsRepositories
{
    private readonly AppDbContext _dBContext;
    public InstructorsRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<InstructorDTO>> GetInstructors()
    {
        return await _dBContext.Instructors
             .AsNoTracking()
             .Select(c => new InstructorDTO
             {
                 InstructorID = c.ID,
                 InstructorName = c.Name,
                 InstructorEmail = c.Email,
                 InstructorPhone = c.Phone
             })
             .ToListAsync();
    }

    public async Task<InstructorsModel> GetByID(int id)
    {
        return await _dBContext.Set<InstructorsModel>().FindAsync(id);
    }
    public async Task<InstructorDTO> GetInstructorByID(int id)
    {
        var instructor = await _dBContext.Instructors
                .Where(c => c.ID == id)
                .Select(c => new InstructorDTO
                {
                    InstructorID = c.ID,
                    InstructorName = c.Name,
                    InstructorEmail = c.Email,
                    InstructorPhone = c.Phone
                })
                 .FirstOrDefaultAsync();

        if (instructor == null)
        {
            throw new Exception($"Instructor Id: {id} not found");
        }

        return instructor;
    }


    public async Task<InstructorsModel> SetInstructor(InstructorsModel instructors)
    {
        try
        {
            await _dBContext.Instructors.AddAsync(instructors);
            await _dBContext.SaveChangesAsync();
            return instructors;

        }catch (Exception ex)
        {
            throw new Exception($"Instructor not created");
        }

    }

    public async Task<InstructorsModel> UpdateInstructor(InstructorsModel instructors, int id)
    {
        InstructorsModel instructorbyID = await GetByID(id);

        if (instructorbyID == null)
        {
            throw new Exception($"Instructor Id: {id} not found");
        }
        instructorbyID.ID = instructorbyID.ID;
        instructorbyID.Name = instructors.Name;
        instructorbyID.Email = instructors.Email;      
        instructorbyID.Phone = instructors.Phone;

        try
        {
            _dBContext.Instructors.Update(instructorbyID);
            await _dBContext.SaveChangesAsync();

            return instructorbyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Instructor Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        InstructorsModel instructorbyID = await GetByID(id);

        if (instructorbyID == null)
        {
            throw new Exception($"Instructor Id: {id} not found");
        }

        try
        {
            _dBContext.Instructors.Remove(instructorbyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Instructor Id: {id} not deleted");
        }
    }

}
