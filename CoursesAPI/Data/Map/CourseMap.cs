﻿using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesAPI.Data.Map;

public class CourseMap : IEntityTypeConfiguration<CourseModel>
{
  
    public void Configure(EntityTypeBuilder<CourseModel> builder)
    {
        builder.HasKey(x => x.ID);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Thumbnail).IsRequired();
        builder.Property(x => x.CategoryID).IsRequired();
        builder.Property(x => x.InstructorID).IsRequired();
    }
}