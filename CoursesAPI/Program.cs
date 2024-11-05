using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoursesAPI.Data;
using CoursesAPI.Repositories;
using CoursesAPI.Repositories.Interface;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CoursesAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );
        builder.Services.AddScoped<IAssessmentRepositories, AssessmentRepositories>();
        builder.Services.AddScoped<ICourseRepositories, CourseRepositories>();
        builder.Services.AddScoped<ICategoryRepositories, CategoryRepositories>();
        builder.Services.AddScoped<IClassRepositories, ClassRepositories>();
        builder.Services.AddScoped<IModuleRepositories, ModuleRepositories>();
        builder.Services.AddScoped<IStudentsRepositories, StudentsRepositories>();
        builder.Services.AddScoped<IInstructorsRepositories, InstructorsRepositories>();
        builder.Services.AddScoped<IRegistrationRepositories, RegistrationRepositories>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(MyAllowSpecificOrigins);
        app.UseHttpsRedirection();

        app.UseAuthorization();
      
        //app.UseRouting();
        //app.UseEndpoints(Endpoint: IEndpointRouteBuilder =>
        //{
        //    endpoints.MapControllerRoute(
        //        name: default,
        //        pattern: "{controller=Home}/{action=Index}/{id?}");
        //});

        app.MapControllers();

        app.Run();
    }
}