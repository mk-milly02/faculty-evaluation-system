using FacultyEvaluationSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacultyEvaluationSystem.Infrastructure;

public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
{
    public void Configure(EntityTypeBuilder<Lecturer> builder)
    {
        builder.HasKey(x => x.LectureId);
        builder.Property(x => x.LectureId).ValueGeneratedOnAdd();
    }
}
