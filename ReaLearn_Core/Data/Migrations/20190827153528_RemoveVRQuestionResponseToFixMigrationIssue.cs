using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class RemoveVRQuestionResponseToFixMigrationIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VRQuestionResponse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VRQuestionResponse",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Response = table.Column<string>(nullable: true),
                    VRQuestionId = table.Column<int>(nullable: false),
                    isCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRQuestionResponse", x => x.id);
                    table.ForeignKey(
                        name: "FK_VRQuestionResponse_VRObject_VRQuestionId",
                        column: x => x.VRQuestionId,
                        principalTable: "VRObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VRQuestionResponse_VRQuestionId",
                table: "VRQuestionResponse",
                column: "VRQuestionId");
        }
    }
}
