using Microsoft.EntityFrameworkCore;
using CoursesAPI.Models;
using System.Reflection;

namespace CoursesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<AssessmentModel> Assessment { get; set; }
    public DbSet<ClassModel> Class { get; set; }
    public DbSet<CategoryModel> Category { get; set; }
    public DbSet<CourseModel> Course { get; set; }
    public DbSet<InstructorsModel> Instructors { get; set; }
    public DbSet<CourseSyllabusModel> CourseSyllabus { get; set; }
    public DbSet<ModuleModel> Module { get; set; }
    public DbSet<StudentModel> Students { get; set; }
    public DbSet<StudentProgressModel> StudentProgress { get; set; }
    public DbSet<RegistrationModel> Registration { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica automaticamente todas as configurações de entidade no assembly atual
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
