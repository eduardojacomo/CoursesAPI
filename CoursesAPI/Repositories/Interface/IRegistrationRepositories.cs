using CoursesAPI.DTOs;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories.Interface;

public interface IRegistrationRepositories
{
    Task<List<RegistrationDTO>> GetRegistrations();
    Task<RegistrationModel> GetByID(int id);
    Task<RegistrationDTO> GetByIDE(Guid ide);
    Task<RegistrationModel> SetRegistration(RegistrationModel registration);
    Task<RegistrationModel> UpdateRegistration(RegistrationModel registration, int id);
    Task<bool> Delete(int id);
}
