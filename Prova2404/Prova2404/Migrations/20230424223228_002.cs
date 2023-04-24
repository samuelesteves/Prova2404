using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova2404.Migrations
{
    /// <inheritdoc />
    public partial class _002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "alunos",
                newName: "IdAluno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAluno",
                table: "alunos",
                newName: "Id");
        }
    }
}
