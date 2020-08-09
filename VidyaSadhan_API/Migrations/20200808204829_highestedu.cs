using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class highestedu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HighestEducation",
                table: "Instructor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestEducation",
                table: "Instructor");
        }
    }
}
