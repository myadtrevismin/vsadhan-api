using Microsoft.EntityFrameworkCore.Migrations;

namespace VidyaSadhan_API.Migrations
{
    public partial class Attendanceboolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Attendances",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Attendances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Attendances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Attendances");
        }
    }
}
