using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatScore.Data.Migrations
{
    public partial class RemoveWinRatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinRatio",
                table: "LeagueStats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WinRatio",
                table: "LeagueStats",
                type: "float",
                nullable: false,
                computedColumnSql: "(CAST([Wins] AS FLOAT) / CAST([Wins] + [Losses] + [Draws] AS FLOAT)) * 100");
        }
    }
}
