using FacultyEvaluationSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacultyEvaluationSystem.Infrastructure;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.CourseId);
        builder.Property(x => x.CourseId).ValueGeneratedOnAdd();
        builder.Property(x => x.CourseCode).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(10).HasMaxLength(100).IsRequired();
    }
}
