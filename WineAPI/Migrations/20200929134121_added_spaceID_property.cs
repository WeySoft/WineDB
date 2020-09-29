using Microsoft.EntityFrameworkCore.Migrations;

namespace WineAPI.Migrations
{
    public partial class added_spaceID_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shouldbedrunken",
                table: "Wines");

            migrationBuilder.AddColumn<string>(
                name: "spaceID",
                table: "Wines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "spaceID",
                table: "Wines");

            migrationBuilder.AddColumn<int>(
                name: "shouldbedrunken",
                table: "Wines",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
