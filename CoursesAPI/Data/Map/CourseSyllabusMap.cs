using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class CourseSyllabusMap : IEntityTypeConfiguration<CourseSyllabusModel>
{
  
    public void Configure(EntityTypeBuilder<CourseSyllabusModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.ModuleID).IsRequired();
        builder.Property(x => x.CourseID).IsRequired();
    }
}
