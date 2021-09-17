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
    [Migration("20210917000602_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

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

                    b.Property<int>("PrestamosId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaId");

                    b.HasIndex("PrestamosId");

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

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Personas", b =>
                {
                    b.HasOne("RegistroPrestamos.Models.Prestamos", null)
                        .WithMany("PersonaId")
                        .HasForeignKey("PrestamosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegistroPrestamos.Models.Prestamos", b =>
                {
                    b.Navigation("PersonaId");
                });
#pragma warning restore 612, 618
        }
    }
}
