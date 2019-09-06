using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class RevertingToSceneHavingBackgroundImageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "BackgroundImageId",
                table: "Scenes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_BackgroundImageId",
                table: "Scenes",
                column: "BackgroundImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_BackgroundImage_BackgroundImageId",
                table: "Scenes",
                column: "BackgroundImageId",
                principalTable: "BackgroundImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_BackgroundImage_BackgroundImageId",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_BackgroundImageId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "BackgroundImageId",
                table: "Scenes");

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
    }
}
