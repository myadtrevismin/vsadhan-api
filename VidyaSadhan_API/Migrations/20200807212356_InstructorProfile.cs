using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class InstructorProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicTypeAcademyTypeId",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcademyTypeId",
                table: "Instructor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvailableDays",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Board",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DemoLink",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HourlyRate",
                table: "Instructor",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<byte[]>(
                name: "IdDoc",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdType",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intersets",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTutorBefore",
                table: "Instructor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preference",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreferredDistance",
                table: "Instructor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PreferredTimeSlot",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalDescription",
                table: "Instructor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subjects",
                table: "Instructor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_AcademicTypeAcademyTypeId",
                table: "Instructor",
                column: "AcademicTypeAcademyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_AcademicTypes_AcademicTypeAcademyTypeId",
                table: "Instructor",
                column: "AcademicTypeAcademyTypeId",
                principalTable: "AcademicTypes",
                principalColumn: "AcademyTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_AcademicTypes_AcademicTypeAcademyTypeId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_AcademicTypeAcademyTypeId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "AcademicTypeAcademyTypeId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "AcademyTypeId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "AvailableDays",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Board",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "DemoLink",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "IdDoc",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "IdType",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Intersets",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "IsTutorBefore",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Preference",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "PreferredDistance",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "PreferredTimeSlot",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "ProfessionalDescription",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Subjects",
                table: "Instructor");
        }
    }
}
