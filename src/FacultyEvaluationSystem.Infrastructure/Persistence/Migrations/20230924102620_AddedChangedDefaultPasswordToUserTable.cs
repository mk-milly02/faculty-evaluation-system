using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultyEvaluationSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedChangedDefaultPasswordToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangedDefaultPassword",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangedDefaultPassword",
                table: "Users");
        }
    }
}
