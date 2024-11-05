using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class InstructorsMap : IEntityTypeConfiguration<InstructorsModel>
{
  
    public void Configure(EntityTypeBuilder<InstructorsModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(35);
    }
}
