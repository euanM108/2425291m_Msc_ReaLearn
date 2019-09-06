using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class SetUpForBackgroundVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackgroundImage");

            migrationBuilder.CreateTable(
                name: "VRBackground",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileType = table.Column<string>(nullable: true),
                    Img = table.Column<byte[]>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    SceneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRBackground", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VRBackground_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VRBackground_SceneId",
                table: "VRBackground",
                column: "SceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VRBackground");

            migrationBuilder.CreateTable(
                name: "BackgroundImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Colour = table.Column<string>(nullable: true),
                    Img = table.Column<byte[]>(nullable: true),
                    SceneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackgroundImage_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundImage_SceneId",
                table: "BackgroundImage",
                column: "SceneId");
        }
    }
}
