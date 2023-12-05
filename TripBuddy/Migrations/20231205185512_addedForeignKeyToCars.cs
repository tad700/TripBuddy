using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBuddy.Migrations
{
    public partial class addedForeignKeyToCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manifacturer",
                table: "Cars",
                newName: "Manufacturer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Cars",
                newName: "Manifacturer");
        }
    }
}
