using Microsoft.EntityFrameworkCore.Migrations;

namespace KLabs.DataAccess.Migrations
{
    public partial class SolutionTitleRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Solutions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Solutions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
