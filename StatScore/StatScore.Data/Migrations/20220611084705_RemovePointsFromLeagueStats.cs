using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatScore.Data.Migrations
{
    public partial class RemovePointsFromLeagueStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "LeagueStats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Points",
                table: "LeagueStats",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
