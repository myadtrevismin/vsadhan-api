using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Langitude",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Course",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Langitude",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Course");
        }
    }
}
