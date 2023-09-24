using FacultyEvaluationSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacultyEvaluationSystem.Infrastructure;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new()
            {
                Id = Guid.NewGuid(),
                Name = nameof(Roles.Lecturer),
                NormalizedName = nameof(Roles.Lecturer).ToUpper()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = nameof(Roles.Student),
                NormalizedName = nameof(Roles.Student).ToUpper()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = nameof(Roles.Administrator),
                NormalizedName = nameof(Roles.Administrator).ToUpper()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = nameof(Roles.DepartmentHead),
                NormalizedName = nameof(Roles.DepartmentHead).ToUpper()
            }
        );
    }
}
