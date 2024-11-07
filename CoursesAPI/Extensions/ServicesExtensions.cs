using Microsoft.EntityFrameworkCore;
using CoursesAPI.Data;
using CoursesAPI.Repositories;
using CoursesAPI.Repositories.Interface;
using Microsoft.OpenApi.Models;

namespace CoursesAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: policyName,
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });
    }

    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DataBase")));
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAssessmentRepositories, AssessmentRepositories>();
        services.AddScoped<ICourseRepositories, CourseRepositories>();
        services.AddScoped<ICategoryRepositories, CategoryRepositories>();
        services.AddScoped<IClassRepositories, ClassRepositories>();
        services.AddScoped<IModuleRepositories, ModuleRepositories>();
        services.AddScoped<IStudentsRepositories, StudentsRepositories>();
        services.AddScoped<IStudentProgressRepositories, StudentProgressRepositories>();
        services.AddScoped<IInstructorsRepositories, InstructorsRepositories>();
        services.AddScoped<IRegistrationRepositories, RegistrationRepositories>();
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Course API",
                Description = "An ASP.NET Core Web API for managing Courses Management",
                TermsOfService = new Uri("https://courseapi.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Jácomo",
                    Url = new Uri("https://eduardojacomo.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://courseapi.com/license")
                }
            });
        });
    }
}
