using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGit.Migrations
{
    public partial class Added_location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WeatherForecasts");
        }
    }
}
