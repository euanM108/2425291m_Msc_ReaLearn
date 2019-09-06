using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class FullRefactoringToAddVRObjectModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SceneQuestions");

            migrationBuilder.CreateTable(
                name: "VRObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    xPos = table.Column<int>(nullable: false),
                    yPos = table.Column<int>(nullable: false),
                    zPos = table.Column<int>(nullable: false),
                    xScale = table.Column<int>(nullable: false),
                    yScale = table.Column<int>(nullable: false),
                    zScale = table.Column<int>(nullable: false),
                    HTML = table.Column<string>(nullable: true),
                    ObjectType = table.Column<string>(nullable: true),
                    SceneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VRObject_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VRObject_SceneId",
                table: "VRObject",
                column: "SceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VRObject");

            migrationBuilder.CreateTable(
                name: "SceneQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    SceneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneQuestions_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestions_SceneId",
                table: "SceneQuestions",
                column: "SceneId");
        }
    }
}
