using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class StudentProgressMap : IEntityTypeConfiguration<StudentProgressModel>
{
  
    public void Configure(EntityTypeBuilder<StudentProgressModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.CompletionDate).IsRequired();
        builder.Property(x => x.RegistrationIDE).IsRequired();
        builder.Property(x => x.RegistrationID).IsRequired();
        builder.Property(x => x.ModuleID).IsRequired();
        builder.Property(x => x.ClassID).IsRequired();

        builder.HasOne(sp => sp.Registration)
               .WithMany(r => r.StudentProgress)
               .HasForeignKey(sp => sp.RegistrationID);

        builder.HasOne(sp => sp.Module)
               .WithMany(r => r.StudentProgress)
               .HasForeignKey(sp => sp.ModuleID);

        builder.HasOne(sp => sp.Class)
               .WithMany(r => r.StudentProgress)
               .HasForeignKey(sp => sp.ClassID);
    }
}
