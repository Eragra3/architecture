using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KekManager.Database.Migrations
{
    public partial class AddedResearchFellow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResearchFellow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchFellow", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ResearchFellow",
                columns: new[] { "Id", "FirstName", "LastName", "Title", "UserId" },
                values: new object[] { 1, "Daniel", "Bider", "inż.", 3 });

            migrationBuilder.InsertData(
                table: "ResearchFellow",
                columns: new[] { "Id", "FirstName", "LastName", "Title", "UserId" },
                values: new object[] { 2, "Szymon", "Barańczyk", "inż.", null });

            migrationBuilder.InsertData(
                table: "ResearchFellow",
                columns: new[] { "Id", "FirstName", "LastName", "Title", "UserId" },
                values: new object[] { 3, "John", "Doe", "mgr inż.", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchFellow");
        }
    }
}
