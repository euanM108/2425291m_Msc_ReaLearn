using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class removeHotSpotObjectToFixMigrationIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "OnClick",
                table: "VRObject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "VRObject",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "VRObject",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OnClick",
                table: "VRObject",
                nullable: true);
        }
    }
}
