using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBuddy.Migrations
{
    public partial class changedUserModelRemovedList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_TripBuddyUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Trips_UserId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TripBuddyUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TripBuddyUserId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarsID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarsID",
                table: "AspNetUsers",
                column: "CarsID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cars_CarsID",
                table: "AspNetUsers",
                column: "CarsID",
                principalTable: "Cars",
                principalColumn: "CarsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cars_CarsID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Trips_UserId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarsID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarsID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TripBuddyUserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TripBuddyUserId",
                table: "Cars",
                column: "TripBuddyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_TripBuddyUserId",
                table: "Cars",
                column: "TripBuddyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
