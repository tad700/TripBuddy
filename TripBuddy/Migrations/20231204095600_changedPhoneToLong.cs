using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBuddy.Migrations
{
    public partial class changedPhoneToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Phone",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Phone",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
