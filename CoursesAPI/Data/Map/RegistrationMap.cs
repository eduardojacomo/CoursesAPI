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
 
    }
}
