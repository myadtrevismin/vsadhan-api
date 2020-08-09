using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class ProfilePic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorUserId",
                table: "CourseAssignment");

            migrationBuilder.DropIndex(
                name: "IX_CourseAssignment_InstructorUserId",
                table: "CourseAssignment");

            migrationBuilder.DropColumn(
                name: "InstructorUserId",
                table: "CourseAssignment");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePic",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "InstructorUserId",
                table: "CourseAssignment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_InstructorUserId",
                table: "CourseAssignment",
                column: "InstructorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssignment_Instructor_InstructorUserId",
                table: "CourseAssignment",
                column: "InstructorUserId",
                principalTable: "Instructor",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
