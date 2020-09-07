using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class stassignmentpk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StudentAssignments",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                columns: new[] { "AssignmentId", "UserId", "CreationDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StudentAssignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                columns: new[] { "AssignmentId", "UserId" });
        }
    }
}
