using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatScore.Data.Migrations
{
    public partial class RemoveLogoFromPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoURL",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoURL",
                table: "Players",
                type: "nvarchar(2048)",
                nullable: false,
                defaultValue: "");
        }
    }
}
