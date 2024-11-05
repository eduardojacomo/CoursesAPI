using CoursesAPI.Data.Map;
using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;

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
    public DbSet<RegistrationModel> Registration { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseModel>()
           .HasOne(c => c.Category)
           .WithMany(cat => cat.Courses)
           .HasForeignKey(c => c.CategoryID);

        modelBuilder.Entity<CourseModel>()
            .HasOne(c => c.Instructor)
            .WithMany(instr => instr.Courses)
            .HasForeignKey(c => c.InstructorID);

        modelBuilder.Entity<CourseSyllabusModel>()
            .HasOne(cs => cs.Course)
            .WithMany(c => c.CourseSyllabi)
            .HasForeignKey(cs => cs.CourseID);

        modelBuilder.Entity<CourseSyllabusModel>()
            .HasOne(cs => cs.Module)
            .WithMany(m => m.CourseSyllabi)
            .HasForeignKey(cs => cs.ModuleID);

        modelBuilder.Entity<ClassModel>()
            .HasOne(cl => cl.Module)
            .WithMany(m => m.Classes)
            .HasForeignKey(cl => cl.ModuleID);

        modelBuilder.ApplyConfiguration(new ClassMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new CourseMap());
        modelBuilder.ApplyConfiguration(new AssessmentMap());
        modelBuilder.ApplyConfiguration(new CourseSyllabusMap());
        modelBuilder.ApplyConfiguration(new InstructorsMap());
        modelBuilder.ApplyConfiguration(new ModuleMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
        modelBuilder.ApplyConfiguration(new RegistrationMap());
        base.OnModelCreating(modelBuilder);
    }
}
