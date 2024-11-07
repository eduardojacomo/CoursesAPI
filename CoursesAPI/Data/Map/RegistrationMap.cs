using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class RegistrationMap : IEntityTypeConfiguration<RegistrationModel>
{
  
    public void Configure(EntityTypeBuilder<RegistrationModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.CourseID).IsRequired();
        builder.Property(x => x.StudentID).IsRequired();
        builder.Property(x => x.RegistrationDate).IsRequired();
        builder.Property(x => x.IDE).IsRequired();

        builder.HasOne(r => r.Course)
               .WithMany(c => c.Registration)
               .HasForeignKey(r => r.CourseID);

        builder.HasOne(r => r.Student)
               .WithMany(c => c.Registration)
               .HasForeignKey(r => r.StudentID);
    }
}
