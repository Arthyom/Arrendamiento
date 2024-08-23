using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class MakeNullApellidoMaterno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "arrendador",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8mb4_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "arrendador",
                keyColumn: "ApellidoMaterno",
                keyValue: null,
                column: "ApellidoMaterno",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "arrendador",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                collation: "utf8mb4_unicode_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_unicode_ci");
        }
    }
}
