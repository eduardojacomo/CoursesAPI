using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class AssessmentMap : IEntityTypeConfiguration<AssessmentModel>
{
  
    public void Configure(EntityTypeBuilder<AssessmentModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.ModuleID).IsRequired();
        builder.Property(x => x.StudentID).IsRequired();
        builder.Property(x => x.Comments).IsRequired();
        builder.Property(x => x.Score).IsRequired();

        builder.HasOne(a => a.Student)
               .WithMany(c => c.Assessment)
               .HasForeignKey(a => a.StudentID);
        builder.HasOne(a => a.Module)
               .WithMany(c => c.Assessment)
               .HasForeignKey(a => a.ModuleID);
    }
}
