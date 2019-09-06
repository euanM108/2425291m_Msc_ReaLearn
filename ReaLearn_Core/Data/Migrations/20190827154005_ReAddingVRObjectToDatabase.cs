using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaLearn_Core.Data.Migrations
{
    public partial class ReAddingVRObjectToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VRObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    xPos = table.Column<double>(nullable: false),
                    yPos = table.Column<double>(nullable: false),
                    zPos = table.Column<double>(nullable: false),
                    xScale = table.Column<double>(nullable: false),
                    yScale = table.Column<double>(nullable: false),
                    zScale = table.Column<double>(nullable: false),
                    xRot = table.Column<int>(nullable: false),
                    yRot = table.Column<int>(nullable: false),
                    zRot = table.Column<int>(nullable: false),
                    ObjectType = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    SceneId = table.Column<int>(nullable: false),
                    Colour = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VRObject");
        }
    }
}
