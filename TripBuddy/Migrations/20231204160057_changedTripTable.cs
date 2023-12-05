using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBuddy.Migrations
{
    public partial class changedTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fuel_Needed",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Price_For_Trip",
                table: "Trips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Fuel_Needed",
                table: "Trips",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<double>(
                name: "Price_For_Trip",
                table: "Trips",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
