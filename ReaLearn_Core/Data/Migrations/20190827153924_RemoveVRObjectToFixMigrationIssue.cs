using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class RemoveVRObjectToFixMigrationIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VRObject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VRObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Colour = table.Column<string>(nullable: true),
                    ObjectType = table.Column<string>(nullable: true),
                    SceneId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    xPos = table.Column<double>(nullable: false),
                    xRot = table.Column<int>(nullable: false),
                    xScale = table.Column<double>(nullable: false),
                    yPos = table.Column<double>(nullable: false),
                    yRot = table.Column<int>(nullable: false),
                    yScale = table.Column<double>(nullable: false),
                    zPos = table.Column<double>(nullable: false),
                    zRot = table.Column<int>(nullable: false),
                    zScale = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VRObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VRObject_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VRObject_SceneId",
                table: "VRObject",
                column: "SceneId");
        }
    }
}
