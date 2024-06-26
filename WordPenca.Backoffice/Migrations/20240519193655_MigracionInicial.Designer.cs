﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordPenca.Business.Persistence;

#nullable disable

namespace WordPenca.Backoffice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519193655_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WordPenca.Business.Domain.Apuesta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GolesLocal")
                        .HasColumnType("int");

                    b.Property<int>("GolesVisitante")
                        .HasColumnType("int");

                    b.Property<Guid>("Partidoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Partidoid");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Campionato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Clasificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Derrotas")
                        .HasColumnType("int");

                    b.Property<int>("Empatados")
                        .HasColumnType("int");

                    b.Property<Guid>("Equipoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GolesAF")
                        .HasColumnType("int");

                    b.Property<int>("GolesEC")
                        .HasColumnType("int");

                    b.Property<int>("PartidosJugados")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.Property<Guid?>("TablaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Victorias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Equipoid");

                    b.HasIndex("TablaId");

                    b.ToTable("Clasificacions");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Equipo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampionatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Partidoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CampionatoId");

                    b.HasIndex("Partidoid");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Partido", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("golLocal")
                        .HasColumnType("int");

                    b.Property<int>("golVisitante")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Tabla", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampionatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampionatoId");

                    b.ToTable("Tablas");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Chat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLFotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WordPenca.Business.Models.Penca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Comision")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("penca");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Apuesta", b =>
                {
                    b.HasOne("WordPenca.Business.Domain.Partido", "Partido")
                        .WithMany()
                        .HasForeignKey("Partidoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WordPenca.Business.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partido");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Clasificacion", b =>
                {
                    b.HasOne("WordPenca.Business.Domain.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("Equipoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WordPenca.Business.Domain.Tabla", null)
                        .WithMany("Clasificaciones")
                        .HasForeignKey("TablaId");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Equipo", b =>
                {
                    b.HasOne("WordPenca.Business.Domain.Campionato", null)
                        .WithMany("Equipos")
                        .HasForeignKey("CampionatoId");

                    b.HasOne("WordPenca.Business.Domain.Partido", null)
                        .WithMany("equipos")
                        .HasForeignKey("Partidoid");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Tabla", b =>
                {
                    b.HasOne("WordPenca.Business.Domain.Campionato", "Campionato")
                        .WithMany()
                        .HasForeignKey("CampionatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campionato");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Campionato", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Partido", b =>
                {
                    b.Navigation("equipos");
                });

            modelBuilder.Entity("WordPenca.Business.Domain.Tabla", b =>
                {
                    b.Navigation("Clasificaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
