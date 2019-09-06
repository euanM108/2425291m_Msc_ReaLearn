using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class AddingVRBackgroundImageToScene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Scenes");

            migrationBuilder.AddColumn<int>(
                name: "BackgroundImageId",
                table: "Scenes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VRBackgroundImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Img = table.Column<byte[]>(nullable: true),
                    Colour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRBackgroundImage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_BackgroundImageId",
                table: "Scenes",
                column: "BackgroundImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_VRBackgroundImage_BackgroundImageId",
                table: "Scenes",
                column: "BackgroundImageId",
                principalTable: "VRBackgroundImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_VRBackgroundImage_BackgroundImageId",
                table: "Scenes");

            migrationBuilder.DropTable(
                name: "VRBackgroundImage");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_BackgroundImageId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "BackgroundImageId",
                table: "Scenes");

            migrationBuilder.AddColumn<byte[]>(
                name: "BackgroundImage",
                table: "Scenes",
                nullable: true);
        }
    }
}
