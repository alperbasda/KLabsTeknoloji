using Microsoft.EntityFrameworkCore.Migrations;

namespace KLabs.DataAccess.Migrations
{
    public partial class ServiceTitleRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
