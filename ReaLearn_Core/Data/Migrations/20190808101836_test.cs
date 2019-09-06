using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VRObject_Scenes_SceneId",
                table: "VRObject");

            migrationBuilder.AlterColumn<int>(
                name: "SceneId",
                table: "VRObject",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VRObject_Scenes_SceneId",
                table: "VRObject",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VRObject_Scenes_SceneId",
                table: "VRObject");

            migrationBuilder.AlterColumn<int>(
                name: "SceneId",
                table: "VRObject",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_VRObject_Scenes_SceneId",
                table: "VRObject",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
