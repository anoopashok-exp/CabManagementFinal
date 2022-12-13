using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabManagement.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DriverId",
                table: "Drivers",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_DriverId",
                table: "Drivers",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_DriverId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_DriverId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Drivers");
        }
    }
}
