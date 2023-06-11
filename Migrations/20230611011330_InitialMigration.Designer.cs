﻿// <auto-generated />
using HerrProgLibreriaDigital.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HerrProgLibreriaDigital.Migrations
{
    [DbContext(typeof(AutorContext))]
    [Migration("20230611011330_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("HerrProgLibreriaDigital.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Contemporaneo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("HerrProgLibreriaDigital.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AutorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantPaginas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Genero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Libro");
                });

            modelBuilder.Entity("HerrProgLibreriaDigital.Models.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Calificacion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreSucursal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("StockPermanente")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("LibroSucursal", b =>
                {
                    b.Property<int>("LibrosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SucursalesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LibrosId", "SucursalesId");

                    b.HasIndex("SucursalesId");

                    b.ToTable("LibroSucursal");
                });

            modelBuilder.Entity("HerrProgLibreriaDigital.Models.Libro", b =>
                {
                    b.HasOne("HerrProgLibreriaDigital.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("LibroSucursal", b =>
                {
                    b.HasOne("HerrProgLibreriaDigital.Models.Libro", null)
                        .WithMany()
                        .HasForeignKey("LibrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HerrProgLibreriaDigital.Models.Sucursal", null)
                        .WithMany()
                        .HasForeignKey("SucursalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HerrProgLibreriaDigital.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}
