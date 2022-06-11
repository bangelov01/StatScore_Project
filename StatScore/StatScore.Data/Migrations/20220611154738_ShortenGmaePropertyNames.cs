using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatScore.Data.Migrations
{
    public partial class ShortenGmaePropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeTeamShots",
                table: "Games",
                newName: "HomeShots");

            migrationBuilder.RenameColumn(
                name: "HomeTeamPasses",
                table: "Games",
                newName: "HomePasses");

            migrationBuilder.RenameColumn(
                name: "HomeTeamGoals",
                table: "Games",
                newName: "HomeGoals");

            migrationBuilder.RenameColumn(
                name: "HomeTeamFauls",
                table: "Games",
                newName: "HomeFauls");

            migrationBuilder.RenameColumn(
                name: "AwayTeamShots",
                table: "Games",
                newName: "AwayShots");

            migrationBuilder.RenameColumn(
                name: "AwayTeamPasses",
                table: "Games",
                newName: "AwayPasses");

            migrationBuilder.RenameColumn(
                name: "AwayTeamGoals",
                table: "Games",
                newName: "AwayGoals");

            migrationBuilder.RenameColumn(
                name: "AwayTeamFauls",
                table: "Games",
                newName: "AwayFauls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeShots",
                table: "Games",
                newName: "HomeTeamShots");

            migrationBuilder.RenameColumn(
                name: "HomePasses",
                table: "Games",
                newName: "HomeTeamPasses");

            migrationBuilder.RenameColumn(
                name: "HomeGoals",
                table: "Games",
                newName: "HomeTeamGoals");

            migrationBuilder.RenameColumn(
                name: "HomeFauls",
                table: "Games",
                newName: "HomeTeamFauls");

            migrationBuilder.RenameColumn(
                name: "AwayShots",
                table: "Games",
                newName: "AwayTeamShots");

            migrationBuilder.RenameColumn(
                name: "AwayPasses",
                table: "Games",
                newName: "AwayTeamPasses");

            migrationBuilder.RenameColumn(
                name: "AwayGoals",
                table: "Games",
                newName: "AwayTeamGoals");

            migrationBuilder.RenameColumn(
                name: "AwayFauls",
                table: "Games",
                newName: "AwayTeamFauls");
        }
    }
}
