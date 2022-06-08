using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatScore.Data.Migrations
{
    public partial class AddPointsToLeagueStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Points",
                table: "LeagueStats",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "LeagueStats");
        }
    }
}
