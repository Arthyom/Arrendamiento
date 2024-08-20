using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAndAddColumnsOnRecibos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emision",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "recibo");

            migrationBuilder.AddColumn<string>(
                name: "Concepto",
                table: "recibo",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "recibo",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pagado",
                table: "recibo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "recibo",
                type: "decimal(10,0)",
                precision: 10,
                scale: 0,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concepto",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "Pagado",
                table: "recibo");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "recibo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Emision",
                table: "recibo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "recibo",
                type: "decimal(10,0)",
                precision: 10,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Pago",
                table: "recibo",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
