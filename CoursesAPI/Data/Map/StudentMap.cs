using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class StudentMap : IEntityTypeConfiguration<StudentModel>
{
  
    public void Configure(EntityTypeBuilder<StudentModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Adress).IsRequired().HasMaxLength(128);
        builder.Property(x => x.City).IsRequired().HasMaxLength(50);
        builder.Property(x => x.State).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Complement).IsRequired().HasMaxLength(60);
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(15);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(35);

    }
}
