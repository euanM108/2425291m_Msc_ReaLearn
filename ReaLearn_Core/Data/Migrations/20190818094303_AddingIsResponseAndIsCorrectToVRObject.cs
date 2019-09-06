using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class AddingIsResponseAndIsCorrectToVRObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInteractive",
                table: "VRObject",
                newName: "IsResponse");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "VRObject",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "VRObject");

            migrationBuilder.RenameColumn(
                name: "IsResponse",
                table: "VRObject",
                newName: "IsInteractive");
        }
    }
}
