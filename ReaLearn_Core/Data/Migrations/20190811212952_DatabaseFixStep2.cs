using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class DatabaseFixStep2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SceneId",
                table: "BackgroundImage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundImage_SceneId",
                table: "BackgroundImage",
                column: "SceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackgroundImage_Scenes_SceneId",
                table: "BackgroundImage",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackgroundImage_Scenes_SceneId",
                table: "BackgroundImage");

            migrationBuilder.DropIndex(
                name: "IX_BackgroundImage_SceneId",
                table: "BackgroundImage");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "BackgroundImage");
        }
    }
}
