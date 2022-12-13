using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabManagement.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarNo",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LicenseNo",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Drivers",
                newName: "CarName");

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DriverViewModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverViewModel", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CarNumber",
                table: "Drivers",
                column: "CarNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LicenseNumber",
                table: "Drivers",
                column: "LicenseNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_CarNumber",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_LicenseNumber",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "CarName",
                table: "Drivers",
                newName: "PhoneNo");

            migrationBuilder.AddColumn<string>(
                name: "CarNo",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNo",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
