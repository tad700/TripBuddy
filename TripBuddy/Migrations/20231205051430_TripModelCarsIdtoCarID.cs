using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBuddy.Migrations
{
    public partial class TripModelCarsIdtoCarID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cars_CarsID1",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CarsID1",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CarsID1",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "CarsID",
                table: "Trips",
                newName: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CarID",
                table: "Trips",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cars_CarID",
                table: "Trips",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cars_CarID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CarID",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "Trips",
                newName: "CarsID");

            migrationBuilder.AddColumn<int>(
                name: "CarsID1",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CarsID1",
                table: "Trips",
                column: "CarsID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cars_CarsID1",
                table: "Trips",
                column: "CarsID1",
                principalTable: "Cars",
                principalColumn: "CarsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
