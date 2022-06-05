using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatScore.Data.Migrations
{
    public partial class AddWinRatioComputatedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WinRatio",
                table: "LeagueStats",
                type: "float",
                nullable: false,
                computedColumnSql: "(CAST([Wins] AS FLOAT) / CAST([Wins] + [Losses] + [Draws] AS FLOAT)) * 100",
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WinRatio",
                table: "LeagueStats",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComputedColumnSql: "(CAST([Wins] AS FLOAT) / CAST([Wins] + [Losses] + [Draws] AS FLOAT)) * 100");
        }
    }
}
