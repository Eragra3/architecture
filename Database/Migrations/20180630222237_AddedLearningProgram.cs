using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KekManager.Database.Migrations
{
    public partial class AddedLearningProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Specialization = table.Column<string>(nullable: true),
                    NumberOfSemesters = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    CnpsHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: false),
                    LearningProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_LearningProgram_LearningProgramId",
                        column: x => x.LearningProgramId,
                        principalTable: "LearningProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LearningProgram",
                columns: new[] { "Id", "CnpsHours", "Level", "Mode", "Name", "NumberOfSemesters", "Specialization" },
                values: new object[,]
                {
                    { 1, 700, 1, 2, "Informatyka", 8, "" },
                    { 2, 700, 1, 1, "Informatyka", 7, "" },
                    { 3, 700, 3, 2, "Informatyka", 4, "Projektowanie Systemów Informatycznych" },
                    { 4, 1200, 3, 1, "Informatyka", 3, "Danologia" }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Area", "LearningProgramId", "Name" },
                values: new object[,]
                {
                    { 1, 5, 1, "Aplikacje Webowe" },
                    { 2, 2, 1, "Przedmioty Humanistyczne" },
                    { 3, 1, 1, "Zajęcia Sportowe" },
                    { 4, 5, 2, "Aplikacje Webowe" },
                    { 5, 2, 2, "Przedmioty Humanistyczne" },
                    { 6, 1, 2, "Zajęcia Sportowe" },
                    { 7, 5, 3, "Aplikacje Webowe" },
                    { 8, 2, 3, "Przedmioty Humanistyczne" },
                    { 9, 5, 4, "Aplikacje Webowe" },
                    { 10, 2, 4, "Przedmioty Humanistyczne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Module_LearningProgramId",
                table: "Module",
                column: "LearningProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "LearningProgram");
        }
    }
}
