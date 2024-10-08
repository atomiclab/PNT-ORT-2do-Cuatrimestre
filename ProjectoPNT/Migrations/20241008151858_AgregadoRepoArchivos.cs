using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoPNT.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoRepoArchivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepositorioArchivosId",
                table: "Archivos3D",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepositorioArchivosId1",
                table: "Archivos3D",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RepositorioArchivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositorioArchivos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_RepositorioArchivosId",
                table: "Archivos3D",
                column: "RepositorioArchivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos3D_RepositorioArchivosId1",
                table: "Archivos3D",
                column: "RepositorioArchivosId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                table: "Archivos3D",
                column: "RepositorioArchivosId",
                principalTable: "RepositorioArchivos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId1",
                table: "Archivos3D",
                column: "RepositorioArchivosId1",
                principalTable: "RepositorioArchivos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId",
                table: "Archivos3D");

            migrationBuilder.DropForeignKey(
                name: "FK_Archivos3D_RepositorioArchivos_RepositorioArchivosId1",
                table: "Archivos3D");

            migrationBuilder.DropTable(
                name: "RepositorioArchivos");

            migrationBuilder.DropIndex(
                name: "IX_Archivos3D_RepositorioArchivosId",
                table: "Archivos3D");

            migrationBuilder.DropIndex(
                name: "IX_Archivos3D_RepositorioArchivosId1",
                table: "Archivos3D");

            migrationBuilder.DropColumn(
                name: "RepositorioArchivosId",
                table: "Archivos3D");

            migrationBuilder.DropColumn(
                name: "RepositorioArchivosId1",
                table: "Archivos3D");
        }
    }
}
