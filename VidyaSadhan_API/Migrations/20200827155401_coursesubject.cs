using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class coursesubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Course",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Course",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidEndDate",
                table: "Course",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ValidEndDate",
                table: "Course");
        }
    }
}
