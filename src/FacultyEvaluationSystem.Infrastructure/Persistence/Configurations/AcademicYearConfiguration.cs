using FacultyEvaluationSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacultyEvaluationSystem.Infrastructure;

public class AcademicYearConfiguration : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.HasKey(x => x.AcademicYearId);
        builder.Property(x => x.AcademicYearId).ValueGeneratedOnAdd();
    }
}
