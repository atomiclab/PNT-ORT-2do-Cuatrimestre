using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProyectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoNombreAlRepositorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "RepositorioArchivos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "RepositorioArchivos");
        }
    }
}
