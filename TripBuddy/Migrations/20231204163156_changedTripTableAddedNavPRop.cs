using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBuddy.Migrations
{
    public partial class changedTripTableAddedNavPRop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_UserId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cars_CarsID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CarsID",
                table: "Trips");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "FK_Trips_AspNetUsers_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cars_CarsID1",
                table: "Trips",
                column: "CarsID1",
                principalTable: "Cars",
                principalColumn: "CarsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_UserId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cars_CarsID1",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CarsID1",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CarsID1",
                table: "Trips");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CarsID",
                table: "Trips",
                column: "CarsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_AspNetUsers_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cars_CarsID",
                table: "Trips",
                column: "CarsID",
                principalTable: "Cars",
                principalColumn: "CarsID");
        }
    }
}
