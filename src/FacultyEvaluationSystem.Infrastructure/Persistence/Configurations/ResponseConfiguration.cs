using FacultyEvaluationSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacultyEvaluationSystem.Infrastructure;

public class ResponseConfiguration : IEntityTypeConfiguration<Response>
{
    public void Configure(EntityTypeBuilder<Response> builder)
    {
        builder.HasKey(x => x.ResponseId);
        builder.Property(x => x.ResponseId).ValueGeneratedOnAdd();
    }
}
