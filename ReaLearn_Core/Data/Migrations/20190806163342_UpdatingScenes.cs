using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class UpdatingScenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SceneQuestionResponses");

            migrationBuilder.AddColumn<int>(
                name: "ResponseFourId",
                table: "SceneQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseOneId",
                table: "SceneQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseThreeId",
                table: "SceneQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseTwoId",
                table: "SceneQuestions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponse", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestions_ResponseFourId",
                table: "SceneQuestions",
                column: "ResponseFourId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestions_ResponseOneId",
                table: "SceneQuestions",
                column: "ResponseOneId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestions_ResponseThreeId",
                table: "SceneQuestions",
                column: "ResponseThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneQuestions_ResponseTwoId",
                table: "SceneQuestions",
                column: "ResponseTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseFourId",
                table: "SceneQuestions",
                column: "ResponseFourId",
                principalTable: "QuestionResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseOneId",
                table: "SceneQuestions",
                column: "ResponseOneId",
                principalTable: "QuestionResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseThreeId",
                table: "SceneQuestions",
                column: "ResponseThreeId",
                principalTable: "QuestionResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseTwoId",
                table: "SceneQuestions",
                column: "ResponseTwoId",
                principalTable: "QuestionResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseFourId",
                table: "SceneQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseOneId",
                table: "SceneQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseThreeId",
                table: "SceneQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_SceneQuestions_QuestionResponse_ResponseTwoId",
                table: "SceneQuestions");

            migrationBuilder.DropTable(
                name: "QuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_SceneQuestions_ResponseFourId",
                table: "SceneQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SceneQuestions_ResponseOneId",
                table: "SceneQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SceneQuestions_ResponseThreeId",
                table: "SceneQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SceneQuestions_ResponseTwoId",
                table: "SceneQuestions");

            migrationBuilder.DropColumn(
                name: "ResponseFourId",
                table: "SceneQuestions");

            migrationBuilder.DropColumn(
                name: "ResponseOneId",
                table: "SceneQuestions");

            migrationBuilder.DropColumn(
                name: "ResponseThreeId",
                table: "SceneQuestions");

            migrationBuilder.DropColumn(
                name: "ResponseTwoId",
                table: "SceneQuestions");

            migrationBuilder.CreateTable(
                name: "SceneQuestionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    SceneQuestionId = table.Column<int>(nullable: false)
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
        }
    }
}
