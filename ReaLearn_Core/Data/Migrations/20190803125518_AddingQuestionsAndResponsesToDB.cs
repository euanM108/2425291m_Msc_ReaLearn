using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class AddingQuestionsAndResponsesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SceneQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SceneId = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "SceneQuestionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SceneQuestionId = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneQuestionResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneQuestionResponses_SceneQuestions_SceneQuestionId",
                        column: x => x.SceneQuestionId,
                        principalTable: "SceneQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestionResponses_SceneQuestionId",
                table: "SceneQuestionResponses",
                column: "SceneQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestions_SceneId",
                table: "SceneQuestions",
                column: "SceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SceneQuestionResponses");

            migrationBuilder.DropTable(
                name: "SceneQuestions");
        }
    }
}
