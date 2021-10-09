﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroPrestamos.DAL;

namespace RegistroPrestamos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211009044642_modificando Moras y MorasDetalle")]
    partial class modificandoMorasyMorasDetalle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("RegistroPrestamos.Models.Moras", b =>
                {
                    b.Property<int>("MoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("MoraId");

                    b.ToTable("Moras");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.MorasDetalle", b =>
                {
                    b.Property<int>("MoraDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("MoraDetalleId");

                    b.HasIndex("MoraId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("MorasDetalle");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Personas", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("PersonaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PersonasPersonaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrestamoId");

                    b.HasIndex("PersonasPersonaId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.MorasDetalle", b =>
                {
                    b.HasOne("RegistroPrestamos.Models.Moras", "Mora")
                        .WithMany("MorasDetalle")
                        .HasForeignKey("MoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroPrestamos.Models.Prestamos", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mora");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Prestamos", b =>
                {
                    b.HasOne("RegistroPrestamos.Models.Personas", null)
                        .WithMany("Prestamos")
                        .HasForeignKey("PersonasPersonaId");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Moras", b =>
                {
                    b.Navigation("MorasDetalle");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Personas", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}