using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRolUsuarioTipoDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoDocumentoId",
                table: "Usuarios",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rols_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoDocumentos_TipoDocumentoId",
                table: "Usuarios",
                column: "TipoDocumentoId",
                principalTable: "TipoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rols_RolId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoDocumentos_TipoDocumentoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoDocumentoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
