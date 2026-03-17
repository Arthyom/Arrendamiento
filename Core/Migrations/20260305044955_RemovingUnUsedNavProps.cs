using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class RemovingUnUsedNavProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_propiedad_arrendatario_ArrendatarioId",
                table: "propiedad");

            migrationBuilder.DropIndex(
                name: "IX_propiedad_ArrendatarioId",
                table: "propiedad");

            migrationBuilder.DropColumn(
                name: "ArrendatarioId",
                table: "propiedad");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "interior");

            migrationBuilder.DropColumn(
                name: "PropiedadId",
                table: "arrendatario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArrendatarioId",
                table: "propiedad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "interior",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_unicode_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PropiedadId",
                table: "arrendatario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_propiedad_ArrendatarioId",
                table: "propiedad",
                column: "ArrendatarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_propiedad_arrendatario_ArrendatarioId",
                table: "propiedad",
                column: "ArrendatarioId",
                principalTable: "arrendatario",
                principalColumn: "Id");
        }
    }
}
