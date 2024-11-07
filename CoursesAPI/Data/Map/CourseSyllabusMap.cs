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

        builder.HasOne(cs => cs.Course)
               .WithMany(c => c.CourseSyllabi)
               .HasForeignKey(cs => cs.CourseID);

        builder.HasOne(cs => cs.Module)
               .WithMany(m => m.CourseSyllabi)
               .HasForeignKey(cs => cs.ModuleID);
    }
}
