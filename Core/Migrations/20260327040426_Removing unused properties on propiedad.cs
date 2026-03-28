using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Removingunusedpropertiesonpropiedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interior",
                table: "propiedad");

            migrationBuilder.DropColumn(
                name: "Libre",
                table: "propiedad");

            migrationBuilder.AddColumn<string>(
                name: "Cp",
                table: "propiedad",
                type: "varchar(5)",
                maxLength: 5,
                nullable: true,
                collation: "utf8mb4_unicode_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cp",
                table: "propiedad");

            migrationBuilder.AddColumn<string>(
                name: "Interior",
                table: "propiedad",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8mb4_unicode_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Libre",
                table: "propiedad",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
