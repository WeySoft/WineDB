using Microsoft.EntityFrameworkCore.Migrations;

namespace WineAPI.Migrations
{
    public partial class added_amount_deletet_isdrunk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdrunk",
                table: "Wines");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "Wines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Wines");

            migrationBuilder.AddColumn<bool>(
                name: "isdrunk",
                table: "Wines",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
