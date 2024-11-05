using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class ModuleMap : IEntityTypeConfiguration<ModuleModel>
{
  
    public void Configure(EntityTypeBuilder<ModuleModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.ModuleDescription).IsRequired();
        builder.Property(x => x.ModuleLevel).IsRequired();

    }
}
