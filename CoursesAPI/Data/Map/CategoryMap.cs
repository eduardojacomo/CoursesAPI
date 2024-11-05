using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
{
  
    public void Configure(EntityTypeBuilder<CategoryModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);       
    }
}
