﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordPenca.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    golLocal = table.Column<int>(type: "int", nullable: false),
                    golVisitante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "penca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Comision = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLFotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tablas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampionatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tablas_Campeonatos_CampionatoId",
                        column: x => x.CampionatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    CampionatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Partidoid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipos_Campeonatos_CampionatoId",
                        column: x => x.CampionatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipos_Partidos_Partidoid",
                        column: x => x.Partidoid,
                        principalTable: "Partidos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Partidoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GolesLocal = table.Column<int>(type: "int", nullable: false),
                    GolesVisitante = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apuestas_Partidos_Partidoid",
                        column: x => x.Partidoid,
                        principalTable: "Partidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clasificacions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Equipoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<int>(type: "int", nullable: false),
                    PartidosJugados = table.Column<int>(type: "int", nullable: false),
                    GolesAF = table.Column<int>(type: "int", nullable: false),
                    GolesEC = table.Column<int>(type: "int", nullable: false),
                    Victorias = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false),
                    Empatados = table.Column<int>(type: "int", nullable: false),
                    TablaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clasificacions_Equipos_Equipoid",
                        column: x => x.Equipoid,
                        principalTable: "Equipos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clasificacions_Tablas_TablaId",
                        column: x => x.TablaId,
                        principalTable: "Tablas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_Partidoid",
                table: "Apuestas",
                column: "Partidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioId",
                table: "Apuestas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificacions_Equipoid",
                table: "Clasificacions",
                column: "Equipoid");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificacions_TablaId",
                table: "Clasificacions",
                column: "TablaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CampionatoId",
                table: "Equipos",
                column: "CampionatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_Partidoid",
                table: "Equipos",
                column: "Partidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_CampionatoId",
                table: "Tablas",
                column: "CampionatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Clasificacions");

            migrationBuilder.DropTable(
                name: "penca");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Tablas");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Campeonatos");
        }
    }
}
