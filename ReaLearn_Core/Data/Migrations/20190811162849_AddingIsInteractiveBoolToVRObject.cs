using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class AddingIsInteractiveBoolToVRObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInteractive",
                table: "VRObject",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInteractive",
                table: "VRObject");
        }
    }
}
