using CoursesAPI.Data;
using CoursesAPI.DTOs;
using CoursesAPI.Models;
using CoursesAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Repositories;

public class CourseRepositories: ICourseRepositories
{
    private readonly AppDbContext _dBContext;
    public CourseRepositories(AppDbContext appDBContext)
    {
        _dBContext = appDBContext;
    }

    public async Task<List<CourseModel>> GetCourses()
    {
        return await _dBContext.Course.AsNoTracking().ToListAsync();
    }

    public async Task<CourseModel> GetByID(int id)
    {
        return await _dBContext.Set<CourseModel>().FindAsync(id);
    }


    public async Task<CourseModel> SetCourse(CourseModel course)
    {
        try
        {
            await _dBContext.Course.AddAsync(course);
            await _dBContext.SaveChangesAsync();
            return course;

        }catch (Exception ex)
        {
            throw new Exception($"Course not created");
        }

    }

    public async Task<CourseModel> UpdateCourse(CourseModel course, int id)
    {
        CourseModel coursebyID = await GetByID(id);

        if (coursebyID == null)
        {
            throw new Exception($"Student Id: {id} not found");
        }
        coursebyID.ID = coursebyID.ID;
        coursebyID.Title = course.Title;
        coursebyID.Description = course.Description;
        coursebyID.Thumbnail = course.Thumbnail;
        coursebyID.CategoryID = course.CategoryID;
        coursebyID.InstructorID = course.InstructorID;
        try
        {
            _dBContext.Course.Update(coursebyID);
            await _dBContext.SaveChangesAsync();

            return coursebyID;
        }
        catch (Exception ex)
        {
            throw new Exception($"Course Id: {id} not updated");
        }
    }

    public async Task<bool> Delete(int id)
    {
        CourseModel coursebyID = await GetByID(id);

        if (coursebyID == null)
        {
            throw new Exception($"Course Id: {id} not found");
        }

        try
        {
            _dBContext.Course.Remove(coursebyID);
            await _dBContext.SaveChangesAsync();

            return true;

        }catch (Exception ex)
        {
            throw new Exception($"Course Id: {id} not deleted");
        }
    }

    public async Task<CourseDTO> GetCourseWithModulesAndClasses(int courseId)
    {
        try
        {
            var course = await _dBContext.Course
                .Where(c => c.ID == courseId)
                .Include(c => c.Category)       
                .Include(c => c.Instructor)     
                .Include(c => c.CourseSyllabi)
                    .ThenInclude(cs => cs.Module)
                    .ThenInclude(m => m.Classes)  
                .Select(c => new CourseDTO
                {
                    CourseID = c.ID,
                    CourseTitle = c.Title,
                    CourseDescription = c.Description,
                    CategoryTitle = c.Category.Title,
                    //InstructorName = c.Instructor.Name,
                    Instructor = new InstructorDTO
                    {
                        InstructorID = c.Instructor.ID,
                        InstructorName = c.Instructor.Name,
                        InstructorEmail = c.Instructor.Email,
                        InstructorPhone = c.Instructor.Phone
                    },
                    Modules = c.CourseSyllabi
                        .Where(cs => cs.Module.Classes.Any())  
                        .Select(cs => new ModuleDTO
                        {
                            ModuleID = cs.Module.ID,
                            ModuleTitle = cs.Module.Title,
                            ModuleDescription = cs.Module.ModuleDescription,
                            Classes = cs.Module.Classes.Select(cl => new ClassDTO
                            {
                                ClassTitle = cl.Title,
                                ClassDescription = cl.ClassDescription
                            }).ToList()
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return course;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar o curso com ID {courseId}: {ex.Message}", ex);
        }
    }



}
