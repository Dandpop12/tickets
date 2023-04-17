using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tickets.api.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoRestosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono2",
                table: "Generales_Empresas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono2",
                table: "Generales_Empresas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
