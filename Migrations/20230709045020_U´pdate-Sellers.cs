using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apollo_fleet_management.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSellers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdm",
                table: "Sellers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Sellers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdm",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Sellers");
        }
    }
}
