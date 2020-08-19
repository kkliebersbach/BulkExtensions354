using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkExtensionsIssue354.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityAs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdCs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityBs",
                columns: table => new
                {
                    EntityAId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityBs", x => new { x.EntityAId, x.Id });
                    table.ForeignKey(
                        name: "FK_EntityBs_EntityAs_EntityAId",
                        column: x => x.EntityAId,
                        principalTable: "EntityAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityCs",
                columns: table => new
                {
                    EntityAId = table.Column<int>(nullable: false),
                    EntityBId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCs", x => new { x.EntityAId, x.EntityBId, x.Id });
                    table.ForeignKey(
                        name: "FK_EntityCs_EntityAs_EntityAId",
                        column: x => x.EntityAId,
                        principalTable: "EntityAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityCs_IdCs_Id",
                        column: x => x.Id,
                        principalTable: "IdCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityCs_EntityBs_EntityAId_EntityBId",
                        columns: x => new { x.EntityAId, x.EntityBId },
                        principalTable: "EntityBs",
                        principalColumns: new[] { "EntityAId", "Id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityCs_Id",
                table: "EntityCs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityCs");

            migrationBuilder.DropTable(
                name: "IdCs");

            migrationBuilder.DropTable(
                name: "EntityBs");

            migrationBuilder.DropTable(
                name: "EntityAs");
        }
    }
}
