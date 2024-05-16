using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordPenca.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class PencaNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsuario_Chats_GruposId",
                table: "ChatUsuario");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "penca",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "penca",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GruposId",
                table: "ChatUsuario",
                newName: "ChatId");

            migrationBuilder.AddColumn<decimal>(
                name: "Comision",
                table: "penca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaFin",
                table: "penca",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaInicio",
                table: "penca",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsuario_Chats_ChatId",
                table: "ChatUsuario",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsuario_Chats_ChatId",
                table: "ChatUsuario");

            migrationBuilder.DropColumn(
                name: "Comision",
                table: "penca");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "penca");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "penca");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "penca",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "penca",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "ChatUsuario",
                newName: "GruposId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsuario_Chats_GruposId",
                table: "ChatUsuario",
                column: "GruposId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
