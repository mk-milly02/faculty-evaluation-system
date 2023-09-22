using FacultyEvaluationSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacultyEvaluationSystem.Infrastructure;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.StudentId).ValueGeneratedOnAdd();
        builder.Property(x => x.IndexNumber).HasMaxLength(15).IsRequired();
    }
}
