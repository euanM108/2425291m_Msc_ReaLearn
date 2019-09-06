using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class UpdatingScenesForSceneEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SceneQuestionId",
                table: "QuestionResponse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_SceneQuestionId",
                table: "QuestionResponse",
                column: "SceneQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponse_SceneQuestions_SceneQuestionId",
                table: "QuestionResponse",
                column: "SceneQuestionId",
                principalTable: "SceneQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponse_SceneQuestions_SceneQuestionId",
                table: "QuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponse_SceneQuestionId",
                table: "QuestionResponse");

            migrationBuilder.DropColumn(
                name: "SceneQuestionId",
                table: "QuestionResponse");

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
    }
}
