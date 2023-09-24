using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultyEvaluationSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPrimaryKeyForLecturerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturerLectureId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Lecturers",
                newName: "LecturerId");

            migrationBuilder.RenameColumn(
                name: "LecturerLectureId",
                table: "Courses",
                newName: "LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_LecturerLectureId",
                table: "Courses",
                newName: "IX_Courses_LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturerId",
                table: "Courses",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturerId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "Lecturers",
                newName: "LectureId");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "Courses",
                newName: "LecturerLectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                newName: "IX_Courses_LecturerLectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturerLectureId",
                table: "Courses",
                column: "LecturerLectureId",
                principalTable: "Lecturers",
                principalColumn: "LectureId");
        }
    }
}
