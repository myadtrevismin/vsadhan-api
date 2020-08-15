using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class userdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicTypeAcademyTypeId",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcademyTypeId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Board",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intersets",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subjects",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_AcademicTypeAcademyTypeId",
                table: "Student",
                column: "AcademicTypeAcademyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AcademicTypes_AcademicTypeAcademyTypeId",
                table: "Student",
                column: "AcademicTypeAcademyTypeId",
                principalTable: "AcademicTypes",
                principalColumn: "AcademyTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AcademicTypes_AcademicTypeAcademyTypeId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AcademicTypeAcademyTypeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AcademicTypeAcademyTypeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AcademyTypeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Board",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Intersets",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Subjects",
                table: "Student");
        }
    }
}
