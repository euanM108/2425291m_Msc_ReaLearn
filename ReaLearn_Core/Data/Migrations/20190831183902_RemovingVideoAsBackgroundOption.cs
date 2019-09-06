using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class RemovingVideoAsBackgroundOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "VRBackground");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "VRBackground");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "VRBackground",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "VRBackground",
                nullable: true);
        }
    }
}
