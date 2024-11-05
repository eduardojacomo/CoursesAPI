using CoursesAPI.Data;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class RegistrationRepositories : IRegistrationRepositories
{
    private readonly AppDbContext _dBContext;
    public RegistrationRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<RegistrationModel>> GetRegistrations()
    {
        return await _dBContext.Registration.AsNoTracking().ToListAsync();
    }

    public async Task<RegistrationModel> GetByID(int id)
    {
        return await _dBContext.Set<RegistrationModel>().FindAsync(id);
    }


    public async Task<RegistrationModel> SetRegistration(RegistrationModel registration)
    {
        try
        {
            await _dBContext.Registration.AddAsync(registration);
            await _dBContext.SaveChangesAsync();
            return registration;

        }catch (Exception ex)
        {
            throw new Exception($"Registration not created");
        }

    }

    public async Task<RegistrationModel> UpdateRegistration(RegistrationModel registration, int id)
    {
        RegistrationModel registrationbyID = await GetByID(id);

        if (registrationbyID == null)
        {
            throw new Exception($"Registration Id: {id} not found");
        }
        registrationbyID.ID = registrationbyID.ID;
        registrationbyID.RegistrationDate = registration.RegistrationDate;
        registrationbyID.StudentID = registration.StudentID;
        registrationbyID.CourseID = registration.CourseID;
        try
        {
            _dBContext.Registration.Update(registrationbyID);
            await _dBContext.SaveChangesAsync();

            return registrationbyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Registration Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        RegistrationModel registrationbyID = await GetByID(id);

        if (registrationbyID == null)
        {
            throw new Exception($"Registration Id: {id} not found");
        }

        try
        {
            _dBContext.Registration.Remove(registrationbyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Registration Id: {id} not deleted");
        }
    }

}
