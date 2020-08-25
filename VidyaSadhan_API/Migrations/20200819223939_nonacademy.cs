using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class nonacademy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NaCategory",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NaSubCategory",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NaCategory",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NaSubCategory",
                table: "AspNetUsers");
        }
    }
}
