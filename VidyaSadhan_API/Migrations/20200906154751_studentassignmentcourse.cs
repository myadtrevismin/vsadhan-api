using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class studentassignmentcourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "StudentAssignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_CourseId",
                table: "StudentAssignments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_Course_CourseId",
                table: "StudentAssignments",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_Course_CourseId",
                table: "StudentAssignments");

            migrationBuilder.DropIndex(
                name: "IX_StudentAssignments_CourseId",
                table: "StudentAssignments");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentAssignments");
        }
    }
}
