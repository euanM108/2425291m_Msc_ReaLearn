using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class AddingQuestionCardsInsteadOfTextBeingInteractive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "IsResponse",
                table: "VRObject");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "VRObject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseFourid",
                table: "VRObject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseOneid",
                table: "VRObject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseThreeid",
                table: "VRObject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseTwoid",
                table: "VRObject",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VRQuestionResponse",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isCorrect = table.Column<bool>(nullable: false),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRQuestionResponse", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VRObject_ResponseFourid",
                table: "VRObject",
                column: "ResponseFourid");

            migrationBuilder.CreateIndex(
                name: "IX_VRObject_ResponseOneid",
                table: "VRObject",
                column: "ResponseOneid");

            migrationBuilder.CreateIndex(
                name: "IX_VRObject_ResponseThreeid",
                table: "VRObject",
                column: "ResponseThreeid");

            migrationBuilder.CreateIndex(
                name: "IX_VRObject_ResponseTwoid",
                table: "VRObject",
                column: "ResponseTwoid");

            migrationBuilder.AddForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseFourid",
                table: "VRObject",
                column: "ResponseFourid",
                principalTable: "VRQuestionResponse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseOneid",
                table: "VRObject",
                column: "ResponseOneid",
                principalTable: "VRQuestionResponse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseThreeid",
                table: "VRObject",
                column: "ResponseThreeid",
                principalTable: "VRQuestionResponse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseTwoid",
                table: "VRObject",
                column: "ResponseTwoid",
                principalTable: "VRQuestionResponse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseFourid",
                table: "VRObject");

            migrationBuilder.DropForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseOneid",
                table: "VRObject");

            migrationBuilder.DropForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseThreeid",
                table: "VRObject");

            migrationBuilder.DropForeignKey(
                name: "FK_VRObject_VRQuestionResponse_ResponseTwoid",
                table: "VRObject");

            migrationBuilder.DropTable(
                name: "VRQuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_VRObject_ResponseFourid",
                table: "VRObject");

            migrationBuilder.DropIndex(
                name: "IX_VRObject_ResponseOneid",
                table: "VRObject");

            migrationBuilder.DropIndex(
                name: "IX_VRObject_ResponseThreeid",
                table: "VRObject");

            migrationBuilder.DropIndex(
                name: "IX_VRObject_ResponseTwoid",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "ResponseFourid",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "ResponseOneid",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "ResponseThreeid",
                table: "VRObject");

            migrationBuilder.DropColumn(
                name: "ResponseTwoid",
                table: "VRObject");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "VRObject",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResponse",
                table: "VRObject",
                nullable: false,
                defaultValue: false);
        }
    }
}
