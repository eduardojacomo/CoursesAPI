using CoursesAPI.Data;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class StudentsRepositories:IStudentsRepositories
{
    private readonly AppDbContext _dBContext;
    public StudentsRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<StudentModel>> GetStudents()
    {
        return await _dBContext.Students.AsNoTracking().ToListAsync();
    }

    public async Task<StudentModel> GetByID(int id)
    {
        return await _dBContext.Set<StudentModel>().FindAsync(id);
    }


    public async Task<StudentModel> SetStudent(StudentModel students)
    {
        try
        {
            await _dBContext.Students.AddAsync(students);
            await _dBContext.SaveChangesAsync();
            return students;

        }catch (Exception ex)
        {
            throw new Exception($"Student not created");
        }

    }

    public async Task<StudentModel> UpdateStudent(StudentModel students, int id)
    {
        StudentModel studentbyID = await GetByID(id);

        if (studentbyID == null)
        {
            throw new Exception($"Student Id: {id} not found");
        }
        studentbyID.ID = studentbyID.ID;
        studentbyID.Name = students.Name;
        studentbyID.Adress = students.Adress;
        studentbyID.City = students.City;
        studentbyID.State = students.State;
        studentbyID.Complement = students.Complement;
        studentbyID.PostalCode = students.PostalCode;
        studentbyID.Phone = students.Phone;

        try
        {
            _dBContext.Students.Update(studentbyID);
            await _dBContext.SaveChangesAsync();

            return studentbyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Student Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        StudentModel studentsbyID = await GetByID(id);

        if (studentsbyID == null)
        {
            throw new Exception($"Student Id: {id} not found");
        }

        try
        {
            _dBContext.Students.Remove(studentsbyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Student Id: {id} not deleted");
        }
    }

}
