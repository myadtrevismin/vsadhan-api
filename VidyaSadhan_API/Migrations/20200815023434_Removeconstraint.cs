using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class Removeconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_StudentId1",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StudentId1",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "TutorId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TutorId",
                table: "Requests",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_TutorId",
                table: "Requests",
                column: "TutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_TutorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_TutorId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "TutorId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId1",
                table: "Requests",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_StudentId1",
                table: "Requests",
                column: "StudentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
