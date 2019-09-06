using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class AddingRotationToVRObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "xRot",
                table: "VRObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yRot",
                table: "VRObject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "zRot",
                table: "VRObject",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xRot",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "yRot",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "zRot",
                table: "VRObject");
        }
    }
}
