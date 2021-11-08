﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P2_AP1_Frankelyn_20190276.DAL;

namespace P2_AP1_Frankelyn_20190276.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211108222951_Agregando Entidad Proyectos al contexto")]
    partial class AgregandoEntidadProyectosalcontexto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("P2_AP1_Frankelyn_20190276.Entidades.Proyectos", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("TiempoTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("P2_AP1_Frankelyn_20190276.Entidades.ProyectosDetalle", b =>
                {
                    b.Property<int>("ProyectoDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoDeTareaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProyectoDetalleId");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("TipoDeTareaId");

                    b.ToTable("ProyectosDetalle");
                });

            modelBuilder.Entity("P2_AP1_Frankelyn_20190276.Entidades.TipoDeTarea", b =>
                {
                    b.Property<int>("TipoDeTareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("TiempoAcumulado")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoDeTareaId");

                    b.ToTable("TipoDeTarea");

                    b.HasData(
                        new
                        {
                            TipoDeTareaId = 1,
                            Descripcion = "Analisis",
                            TiempoAcumulado = 0
                        },
                        new
                        {
                            TipoDeTareaId = 2,
                            Descripcion = "Diseño",
                            TiempoAcumulado = 0
                        },
                        new
                        {
                            TipoDeTareaId = 3,
                            Descripcion = "Programacion",
                            TiempoAcumulado = 0
                        },
                        new
                        {
                            TipoDeTareaId = 4,
                            Descripcion = "Prueba",
                            TiempoAcumulado = 0
                        });
                });

            modelBuilder.Entity("P2_AP1_Frankelyn_20190276.Entidades.ProyectosDetalle", b =>
                {
                    b.HasOne("P2_AP1_Frankelyn_20190276.Entidades.Proyectos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P2_AP1_Frankelyn_20190276.Entidades.TipoDeTarea", "TipoDeTarea")
                        .WithMany()
                        .HasForeignKey("TipoDeTareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeTarea");
                });

            modelBuilder.Entity("P2_AP1_Frankelyn_20190276.Entidades.Proyectos", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}