using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tickets.api.Migrations
{
    /// <inheritdoc />
    public partial class ReestructurandoTablaTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCorta",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "FechaCortaEntrega",
                table: "Tickets",
                newName: "FechaAsignada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaAsignada",
                table: "Tickets",
                newName: "FechaCortaEntrega");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCorta",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
