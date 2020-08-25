using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class assignmenttutorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_InstructorId",
                table: "Assignments",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_InstructorId",
                table: "Assignments",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_InstructorId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_InstructorId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Assignments");
        }
    }
}
