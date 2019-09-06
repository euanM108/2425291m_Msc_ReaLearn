using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class UpdatingUserCourseRelationUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUserRelation_AspNetUsers_UserId1",
                table: "CourseUserRelation");

            migrationBuilder.DropIndex(
                name: "IX_CourseUserRelation_UserId1",
                table: "CourseUserRelation");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CourseUserRelation");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CourseUserRelation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_CourseUserRelation_UserId",
                table: "CourseUserRelation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUserRelation_AspNetUsers_UserId",
                table: "CourseUserRelation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUserRelation_AspNetUsers_UserId",
                table: "CourseUserRelation");

            migrationBuilder.DropIndex(
                name: "IX_CourseUserRelation_UserId",
                table: "CourseUserRelation");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CourseUserRelation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CourseUserRelation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUserRelation_UserId1",
                table: "CourseUserRelation",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUserRelation_AspNetUsers_UserId1",
                table: "CourseUserRelation",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
