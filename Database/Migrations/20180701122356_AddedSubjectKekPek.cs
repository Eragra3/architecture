using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KekManager.Database.Migrations
{
    public partial class AddedSubjectKekPek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    LearningProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kek_LearningProgram_LearningProgramId",
                        column: x => x.LearningProgramId,
                        principalTable: "LearningProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SupervisorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_ResearchFellow_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "ResearchFellow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    KekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pek_Kek_KekId",
                        column: x => x.KekId,
                        principalTable: "Kek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pek_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectKekJoinModel",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false),
                    KekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectKekJoinModel", x => new { x.KekId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectKekJoinModel_Kek_KekId",
                        column: x => x.KekId,
                        principalTable: "Kek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectKekJoinModel_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Name", "SupervisorId" },
                values: new object[,]
                {
                    { 1, "Teleinformatyka", 3 },
                    { 2, "Algorytmy i Struktury Danych", 1 },
                    { 3, "Projektowanie Systemów Informatycznych II", null },
                    { 4, "Analiza Matematyczna I", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kek_LearningProgramId",
                table: "Kek",
                column: "LearningProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Pek_KekId",
                table: "Pek",
                column: "KekId");

            migrationBuilder.CreateIndex(
                name: "IX_Pek_SubjectId",
                table: "Pek",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SupervisorId",
                table: "Subject",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectKekJoinModel_SubjectId",
                table: "SubjectKekJoinModel",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pek");

            migrationBuilder.DropTable(
                name: "SubjectKekJoinModel");

            migrationBuilder.DropTable(
                name: "Kek");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
