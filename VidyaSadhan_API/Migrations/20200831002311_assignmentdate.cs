using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class assignmentdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StudentAssignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "StudentAssignments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmissionFile",
                table: "StudentAssignments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentAssignments");

            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "StudentAssignments");

            migrationBuilder.DropColumn(
                name: "SubmissionFile",
                table: "StudentAssignments");
        }
    }
}
