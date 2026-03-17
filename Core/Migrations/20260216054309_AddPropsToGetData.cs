using Humanizer;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class AddPropsToGetData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //             migrationBuilder.CreateIndex(
            //     name: "IX_arrendatario_PropiedadId",
            //     table: "arrendatario",
            //     column: "PropiedadId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_arrendatario_propiedad_PropiedadId",
            //     table: "arrendatario",
            //     column: "PropiedadId",
            //     principalTable: "propiedad",
            //     principalColumn: "Id");

            migrationBuilder.DropForeignKey(
                name: "FK_arrendatario_propiedad_PropiedadId",
                table: "arrendatario");

            migrationBuilder.DropIndex(
                name: "IX_arrendatario_PropiedadId",
                table: "arrendatario");


            // migrationBuilder.DropForeignKey( table: "propiedad", name: "ArrendatarioId");

            migrationBuilder.AddColumn<int>(
                name: "ArrendatarioId",
                table: "propiedad",
                type: "int",
                nullable: true, 
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_propiedad_ArrendatarioId",
                table: "propiedad",
                column: "ArrendatarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_propiedad_arrendatario_ArrendatarioId",
                table: "propiedad",
                column: "ArrendatarioId",
                principalTable: "arrendatario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_arrendatario_PropiedadId",
                table: "arrendatario",
                column: "PropiedadId");

            migrationBuilder.AddForeignKey(
                name: "FK_arrendatario_propiedad_PropiedadId",
                table: "arrendatario",
                column: "PropiedadId",
                principalTable: "propiedad",
                principalColumn: "Id");
        }
    }
}
