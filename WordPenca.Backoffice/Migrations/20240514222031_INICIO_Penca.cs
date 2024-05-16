using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordPenca.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class INICIO_Penca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatHistorials_ChatGrupos_Id",
                table: "ChatHistorials");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMensajes_ChatHistorials_ChatHistorialId",
                table: "ChatMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Campionatos_CampionatoId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tablas_Campionatos_CampionatoId",
                table: "Tablas");

            migrationBuilder.DropTable(
                name: "ChatGrupoUsuario");

            migrationBuilder.DropTable(
                name: "ChatGrupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatHistorials",
                table: "ChatHistorials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campionatos",
                table: "Campionatos");

            migrationBuilder.RenameTable(
                name: "ChatHistorials",
                newName: "ChatHistorial");

            migrationBuilder.RenameTable(
                name: "Campionatos",
                newName: "Campeonatos");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ChatMensajes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "ChatMensajes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatHistorial",
                table: "ChatHistorial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campeonatos",
                table: "Campeonatos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privado = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "penca",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ChatUsuario",
                columns: table => new
                {
                    GruposId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsuario", x => new { x.GruposId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_ChatUsuario_Chats_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsuario_UsuariosId",
                table: "ChatUsuario",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatHistorial_Chats_Id",
                table: "ChatHistorial",
                column: "Id",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMensajes_ChatHistorial_ChatHistorialId",
                table: "ChatMensajes",
                column: "ChatHistorialId",
                principalTable: "ChatHistorial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Campeonatos_CampionatoId",
                table: "Equipos",
                column: "CampionatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tablas_Campeonatos_CampionatoId",
                table: "Tablas",
                column: "CampionatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatHistorial_Chats_Id",
                table: "ChatHistorial");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMensajes_ChatHistorial_ChatHistorialId",
                table: "ChatMensajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Campeonatos_CampionatoId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tablas_Campeonatos_CampionatoId",
                table: "Tablas");

            migrationBuilder.DropTable(
                name: "ChatUsuario");

            migrationBuilder.DropTable(
                name: "penca");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatHistorial",
                table: "ChatHistorial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campeonatos",
                table: "Campeonatos");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "ChatMensajes");

            migrationBuilder.RenameTable(
                name: "ChatHistorial",
                newName: "ChatHistorials");

            migrationBuilder.RenameTable(
                name: "Campeonatos",
                newName: "Campionatos");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ChatMensajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatHistorials",
                table: "ChatHistorials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campionatos",
                table: "Campionatos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChatGrupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatGrupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatGrupoUsuario",
                columns: table => new
                {
                    GruposId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatGrupoUsuario", x => new { x.GruposId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_ChatGrupoUsuario_ChatGrupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "ChatGrupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatGrupoUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatGrupoUsuario_UsuariosId",
                table: "ChatGrupoUsuario",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatHistorials_ChatGrupos_Id",
                table: "ChatHistorials",
                column: "Id",
                principalTable: "ChatGrupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMensajes_ChatHistorials_ChatHistorialId",
                table: "ChatMensajes",
                column: "ChatHistorialId",
                principalTable: "ChatHistorials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Campionatos_CampionatoId",
                table: "Equipos",
                column: "CampionatoId",
                principalTable: "Campionatos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tablas_Campionatos_CampionatoId",
                table: "Tablas",
                column: "CampionatoId",
                principalTable: "Campionatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
