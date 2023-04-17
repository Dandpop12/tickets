using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tickets.api.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoCapoClasificacionClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_Clasificaciones_ClasificacionId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClasificacionlId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ClasificacionId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_Clasificaciones_ClasificacionId",
                table: "Clientes",
                column: "ClasificacionId",
                principalTable: "Clientes_Clasificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_Clasificaciones_ClasificacionId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ClasificacionId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionlId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_Clasificaciones_ClasificacionId",
                table: "Clientes",
                column: "ClasificacionId",
                principalTable: "Clientes_Clasificaciones",
                principalColumn: "Id");
        }
    }
}
