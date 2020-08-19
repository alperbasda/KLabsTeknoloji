using Microsoft.EntityFrameworkCore.Migrations;

namespace KLabs.DataAccess.Migrations
{
    public partial class ServiceShortDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Solutions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Solutions");
        }
    }
}
