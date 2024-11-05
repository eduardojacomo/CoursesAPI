using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class ClassMap : IEntityTypeConfiguration<ClassModel>
{
  
    public void Configure(EntityTypeBuilder<ClassModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.ClassDescription).IsRequired();
       
    }
}
